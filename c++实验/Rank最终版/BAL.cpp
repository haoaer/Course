
#include"pch.h"
#include"BAL.h"

void CBAL::Game()  //Ëæ»ú¸³·Ö
{
	for (int i = 0; i < 6; i++)
	{
		for (int j = i; j < 6; j++)
		{
			vs[i][j] = rand() % 2;
			if (vs[i][j] == 1)vs[j][i] = 0;
			else vs[j][i] = 1;
		}
	}		
}

void CBAL::renew()
{
	for (int i = 0; i < 6; i++)
	{
		wincount[i] = 0;
		losscount[i] = 0;
	}
	for (int i = 0; i < 6; i++)
	for (int j = 0; j < 6; j++)
		if (i != j)
		{
			if (vs[i][j] == 1)wincount[i]++;
			else losscount[i]++;
		}
}

bool CBAL::iswin()
{
	
	for (int i = 0; i < 6; i++)
		for (int j = i + 1; j < 6; j++)
			if (vs[i][j] == 0)
				return false;

	return true;
}

void CBAL::win()
{
	for (int i = 0; i < 6; i++)
	for (int j = i + 1; j < 6; j++)
	{
		vs[i][j] = 1;
		vs[j][i] = 0;
	}	
}