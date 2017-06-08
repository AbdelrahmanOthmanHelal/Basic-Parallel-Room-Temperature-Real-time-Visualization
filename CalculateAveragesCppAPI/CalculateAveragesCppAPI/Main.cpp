#include <stdexcept>
#include <string>
#include <omp.h>
#include <stdexcept>

using namespace std;

namespace CalculateAveragesCppAPI
{
	extern "C" { __declspec(dllexport) void CalculateAveragesCPP(double* cellTemps, double* cellTempsBackup, int* cellTypes, int* cellTypesBackup, int ColsCount, int RowsCount, int numThreads, int* rowIntersect, int* colIntersect); }
		
	void CalculateAveragesCPP(double* cellTemps, double* cellTempsBackup, int* cellTypes, int* cellTypesBackup, int ColsCount, int RowsCount, int numThreads, int* rowIntersect, int* colIntersect){
		
		// Set the number of threads .. 
		omp_set_num_threads(numThreads);

		// We wanna make it dependent on the run time ..
		#pragma omp parallel for schedule(dynamic,4)

		for (int i = 0; i < RowsCount; i++) {
			for (int j = 0; j < ColsCount; j++) {
				// Computing the linear array index .. 		
				int arrayIndex = (i * ColsCount) + j;
				
				int tempRowValue, tempColValue;
				// Add me to the average sum 
				double temp = cellTemps[arrayIndex], numberOfCells = 1;

				if (cellTypes[arrayIndex] == -1)
				{
					for (int k = 0; k < 8; k++)
					{
						tempRowValue = i + rowIntersect[k];
						tempColValue = j + colIntersect[k];
						if (tempRowValue >= 0 && tempRowValue < RowsCount && tempColValue >= 0 && tempColValue < ColsCount)
						{
							if (cellTypes[(tempRowValue * ColsCount) + tempColValue] != -2)
							{
								temp += cellTemps[(tempRowValue * ColsCount) + tempColValue];
								numberOfCells++;
							}
						}
					}
					// Store the average .. 
					cellTempsBackup[arrayIndex] = (double)(temp / numberOfCells);
				}
			}
		}
	}
}