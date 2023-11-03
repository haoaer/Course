// CmyDlg.cpp: 实现文件
//
#include "framework.h"
#include "pch.h"
#include "Rank.h"
#include "CmyDlg.h"
#include "afxdialogex.h"
#include"MainFrm.h"

// CmyDlg 对话框

IMPLEMENT_DYNAMIC(CmyDlg, CDialog)

CmyDlg::CmyDlg(CWnd* pParent /*=nullptr*/)
	: CDialog(IDD_CmyDlg, pParent)
{

}

CmyDlg::~CmyDlg()
{
}

void CmyDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CmyDlg, CDialog)
	ON_WM_LBUTTONUP()
	ON_WM_TIMER()
//	ON_WM_NCPAINT()
ON_WM_MOUSEMOVE()
END_MESSAGE_MAP()


// CmyDlg 消息处理程序


BOOL CmyDlg::OnInitDialog()
{
	CDialog::OnInitDialog();
	
	// TODO:  在此添加额外的初始化
	CenterWindow();
	Inst();
	Ba.Game();
	Ba.renew();
	SetTimer(1, 50, NULL);

	return TRUE;  // return TRUE unless you set the focus to a control
				  // 异常: OCX 属性页应返回 FALSE
}


void CmyDlg::OnLButtonUp(UINT nFlags, CPoint point)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
	PointF pt(static_cast<float>(point.x), static_cast<float>(point.y));
	if (Tag == false)
	{
		int i;
		for (i = 0; i < 6; i++)
		{
			RectF rf(rr[i].X, rr[i].Y, rr[i].Width, rr[i].Height);
			if (rf.Contains(pt))   //查看详细赛况
			{
				music();
				Tag = !Tag;
				sign = i;
				break;
			}
		}
		
		RectF rf(winr.X, winr.Y, winr.Width, winr.Height); //点击直接胜利区域
		if (rf.Contains(pt))
		{
			Ba.win();
			PlaySound(_T("res\\正确音效.wav"), NULL, SND_FILENAME | SND_ASYNC);//单次播放
		}
	}
	else
	{
		RectF rf1(0, 0, 100,100 );// 返回概况
		if (rf1.Contains(pt))
		{
			Tag = !Tag;
			music();
		}
		for (int i = 0; i < 5; i++)
		{
			RectF rf2(mr[i].X, mr[i].Y, mr[i].Width, mr[i].Height);// 改变比赛
			if (rf2.Contains(pt))
			{
				music();
				if (i < sign)
				{
					Ba.vs[sign][i] = !Ba.vs[sign][i];
					Ba.vs[i][sign] = !Ba.vs[i][sign];
				}
				else
				{
					Ba.vs[sign][i+1] = !Ba.vs[sign][i+1];
					Ba.vs[i+1][sign] = !Ba.vs[i+1][sign];
				}
			}
		}
	}
}

void CmyDlg::Inst()
{
	GetClientRect(rc);
	rr[0].X = 50;      fr[0].X = 75;
	rr[0].Y = 50;	   fr[0].Y = 75;
	rr[0].Width = 150;    fr[0].Width = 180;
	rr[0].Height = 150;   fr[0].Height = 180;
	for (int i = 1; i < 6; i++)
	{
		rr[i].X = rr[i - 1].X;
		rr[i].Y = rr[i - 1].Y + 180;
		rr[i].Width = rr[0].Width;
		rr[i].Height = rr[0].Height;
	}

	for (int i = 1; i < 5; i++)
	{
		fr[i].X = fr[i - 1].X; 
		fr[i].Y = fr[i - 1].Y + 200;
		fr[i].Width = fr[0].Width;
		fr[i].Height = fr[0].Height;
	}
	for (int i = 0; i < 5; i++)
	{
		mr[i].X = fr[i].X + 400;
		mr[i].Y = fr[i].Y+35;
		mr[i].Width = 250;
		mr[i].Height = fr[i].Height-40;
	}
	B[0] = B0;
	B[1] = B1;
	B[2] = B2;
	B[3] = B3;
	B[4] = B4;
	B[5] = B5;
	winr.X = 1050;
	winr.Y = 40;
	winr.Width = 200;
	winr.Height = 200;
}

void CmyDlg::RunDraw()
{
	HDC hdc = ::GetDC(m_hWnd);
	// 客户区的大小
	GetClientRect(rc);

	CDC* dc = CClientDC::FromHandle(hdc);
	// 双缓冲绘图用
	CDC m_dcMemory;
	CBitmap bmp;
	bmp.CreateCompatibleBitmap(dc, rc.Width(), rc.Height());
	m_dcMemory.CreateCompatibleDC(dc);
	CBitmap* pOldBitmap = m_dcMemory.SelectObject(&bmp);
	// 构造对象
	Graphics gh(m_dcMemory.GetSafeHdc());
	// 清除背景
	gh.Clear(Color::White);
	gh.ResetClip();//
	{
		Drawback(gh);
		Drawteam(gh);
		Drawscore(gh);
		Drawwin(gh);
	}

	// 拷贝到屏幕
	::BitBlt(hdc, 0, 0, rc.Width(), rc.Height(),m_dcMemory.GetSafeHdc(), 0, 0, SRCCOPY);
	// 释放
	::ReleaseDC(m_hWnd, hdc);
	return;
}
void CmyDlg::Drawback(Graphics &gh)
{
	gh.DrawImage(back, rc.left, rc.top,rc.Width(),rc.Height());
	if (Tag == false) //画奖杯
	{
		if(winTag==false)
		gh.DrawImage(directwin, winr);
		else 
		gh.DrawImage(directwin, Rect(winr.X-30,winr.Y-30,winr.Width+30,winr.Height+30));
	}
	else gh.DrawImage(retur, Rect(0, 0, 100, 100)); //画返回按钮
}

void CmyDlg::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
	RunDraw();
	Ba.renew();
	
	CDialog::OnTimer(nIDEvent);
}
void CmyDlg::Drawteam(Graphics &gh)
{
	if (Tag == false)  //六个队
	{
		for (int i = 0; i < 6; i++)
		{
			if(BTag[i]==false)
			gh.DrawImage(B[i], rr[i]);
			else 
			gh.DrawImage(B[i], Rect(rr[i].GetLeft()-20,rr[i].GetTop()-20,rr[i].Width+20,rr[i].Height+20));
		}

	}
	else  //五个队
	{
		Rect rt[6];   // 右侧图标位置
		for(int i=0;i<6;i++)
		{
			rt[i].X = rr[i].X + 800;
			rt[i].Y = rr[i].Y;
			rt[i].Width = rr[i].Width;
			rt[i].Height = rr[i].Height;
		}
		int j=0;
		for (int i = 0; i < 5; i++)
		{
			if (sign == j) j++;
			gh.DrawImage(B[sign], fr[i]);
			gh.DrawImage(B[j++], Rect(fr[i].X+950,fr[i].Y,fr[i].Width,fr[i].Height));
		}

	}

}
void CmyDlg::Drawscore(Graphics &gh) 
{
	if (Tag == false)
	{
		CString str[6];
		StringFormat format;
		StringAlignment vsa = StringAlignmentCenter;
		format.SetLineAlignment(vsa);//垂直对齐 行居中
		Gdiplus::Font font(_T("华文琥珀"), 60);
		SolidBrush mybursh(Color(88,138,78));
		for (int i = 0; i < 6; i++)
		{
			str[i].Format(_T("胜%d 负%d"), Ba.wincount[i], Ba.losscount[i]);
			gh.DrawString(str[i], str[i].GetLength(), &font,
			RectF(rr[i].X + 300, rr[i].Y, 800, rr[i].Height), &format, &mybursh);
		}
	}

	else
	{
		int j = 0;
		for (int i = 0; i < 5; i++)
		{
			if (j == sign)j++;
			if (Ba.vs[sign][j] == 1)
				gh.DrawImage(win, mr[i]);
			else gh.DrawImage(loss, mr[i]);
			j++;
		}

	}
}
void CmyDlg::Drawwin(Graphics& gh)
{
	if (Ba.iswin() == true)
		if (Tag == false)
	gh.DrawImage(通关, Rect(900, 900, 250, 130));
}



void CmyDlg::OnMouseMove(UINT nFlags, CPoint point)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
	PointF pt(static_cast<float>(point.x), static_cast<float>(point.y));
	for (int i = 0; i < 6; i++)
	{
		RectF rf(rr[i].X, rr[i].Y, rr[i].Width, rr[i].Height);
		if (rf.Contains(pt))   //图片变大
			BTag[i] = true;
		else BTag[i] = false;
	}
	RectF rf(winr.X, winr.Y, winr.Width, winr.Height);
	if (rf.Contains(pt))
		winTag = true;
	else winTag = false;
	CDialog::OnMouseMove(nFlags, point);
}

void CmyDlg::music()
{
	PlaySound(_T("res\\点击音效.wav"), NULL, SND_FILENAME | SND_ASYNC);//单次播放
}