#pragma once
#include"BAL.h"

// CmyDlg 对话框

class CmyDlg : public CDialog
{
	DECLARE_DYNAMIC(CmyDlg)

public:
	CmyDlg(CWnd* pParent = nullptr);   // 标准构造函数
	virtual ~CmyDlg();
	/************************************************************/
	CRect rc;       //客户区
	Rect rr[6];     //六个队标的区域
	Rect fr[5];     //五个对标的区域
	Rect mr[5];		//五个标志位  
	Rect winr;
	//CDC* picDC[6]; //CDC* picDC1;
	Image* back = Image::FromFile(_T(".\\pic\\back2.JPG"));
	Image* B0 = Image::FromFile(_T(".\\pic\\B0.PNG"));
	Image* B1 = Image::FromFile(_T(".\\pic\\B1.PNG"));
	Image* B2 = Image::FromFile(_T(".\\pic\\B2.PNG"));
	Image* B3 = Image::FromFile(_T(".\\pic\\B3.PNG"));
	Image* B4 = Image::FromFile(_T(".\\pic\\B4.PNG"));
	Image* B5 = Image::FromFile(_T(".\\pic\\B5.PNG"));
	Image* win = Image::FromFile(_T(".\\pic\\win.PNG"));
	Image* loss = Image::FromFile(_T(".\\pic\\loss.PNG"));
	Image* 通关 = Image::FromFile(_T(".\\pic\\通关.PNG"));
	Image* directwin = Image::FromFile(_T(".\\pic\\directwin.PNG"));
	Image* retur = Image::FromFile(_T(".\\pic\\return.PNG"));
	Image* B[6];
	Image* temp;
	CBAL Ba;
	bool BTag[6]{false};
	bool Tag{ false };
	bool winTag{ false };
	int sign{};
	void RunDraw();
	void Inst();
	void Drawback(Graphics& gh);
	void Drawteam(Graphics& gh);
	void Drawscore(Graphics& gh);
	void Drawwin(Graphics& gh);
	void music();
	/************************************************************/
// 对话框数据
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_CmyDlg };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	afx_msg void OnLButtonUp(UINT nFlags, CPoint point);

public:
	
	afx_msg void OnTimer(UINT_PTR nIDEvent);
//	afx_msg void OnNcPaint();
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
};
