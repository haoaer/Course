#pragma once
class CBAL
{
public:
	//CBAL();
	//~CBAL();
	int wincount[6]{0};
	int losscount[6]{0};
	int vs[6][6]{0};
	void Game();
	void renew();
	bool iswin();
	void win();
};

