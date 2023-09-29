#include <iostream>
#include <fstream>
#include <time.h>
#include <windows.h>
void printmaze();
void pacmanup();
void pacmandown();
void pacmanleft();
void pacmanright();
void gotoxy(int,int);
void ghostmovement();
void energizerleft();
void energizerright();
void energizerup();
void energizerdown();
int ghostDirection();
bool ghostMovement();
bool energy();
void stalkerghost();

char maze[24][71] = {
{"#####################################################################"},
{"||.E .....................................................  ......  ||"},
{"||.. %%%%%%%%%%%%%%%%        ...     %%%%%%%%%%%%%%  |%|..   %%%%   ||"},
{"||..        |%|   |%|     |%|...     |%|        |%|  |%| .    |%|   ||"},
{"||..        |%|   |%|     |%|...     |%|        |%|  |%|..    |%|   ||"},
{"||..        %%%%%%%%  . . |%|...     %%%%%%%%%%%%%%     ..   %%%%.  ||"},
{"||..        |%|       . E |%|.E.    ............... |%| ..       .  ||"},
{"||..        %%%%%%%%%%. . |%|...    %%%%%%%%%%%%    |%| .E   %%%%.  ||"},
{"||..               |%|.             |%|......       |%| ..    |%|.  ||"},
{"||..     ......... |%|.             |%|......|%|        ..    |%|.  ||"},
{"||..|%|  |%|%%%|%|.|%|. |%|            ......|%|        ..|%| |%|.  ||"},
{"||..|%|  |%|   |%|..    %%%%%%%%%%%%%  ......|%|         .|%|.      ||"},
{"||..|%|  |%|   |%|..           ...|%|     %%%%%%        . |%|.      ||"},
{"||..|%|            .           ...|%|               |%| ..|%|.      ||"},
{"||..|%|  %%%%%%%%%%%%%%        ...|%|%%%%%%%%%%     |%| ..|%|%%%%%  ||"},
{"||...............................................   |%| ..........  ||"},
{"||   ............................................          .......  ||"},
{"||..|%|  |%|   |%|..    %%%%%%%%%%%%%  ......|%|    |%| ..|%|.      ||"},
{"||..|%|  |%|   |%|..           ...|%|     %%%%%%    |%| ..|%|.      ||"},
{"||..|%|            .           ...|%|               |%| ..|%|.      ||"},
{"||..|%|  %%%%%%%%%%%%%%        ...|%|%%%%%%%%%%     |%| ..|%|%%%%%  ||"},
{"||...............................................   |%| ..........  ||"},
{"||  .............................E...............          .......  ||"}, 
{"#####################################################################"}};


int score=0;
int collisioncounter=0;
int stalkery=34;
int stalkerx=13;
int pacmanx=9;
int pacmany=31;
int ghostX= 19; 
int ghostY= 25; 
int ghostvx=3;
int ghostvy=56;
int ghosthx=16;
int ghosthy=2;
int energizeroutcome;
char previousItem = ' ';


using namespace std;
int main()
{
    bool gamerunning=true;
	system("cls");
	printmaze();
	gotoxy(pacmany,pacmanx);
	cout<<"P";
	while(gamerunning)
	{
    Sleep(100);
	ghostmovement();
	gamerunning = ghostMovement();
	
	
    if(GetAsyncKeyState(VK_LEFT)){
	pacmanleft();
	energizeroutcome=energy();
	if(energizeroutcome==1)
	{energizerleft();}
	}
	
	else if(GetAsyncKeyState(VK_RIGHT)){
	pacmanright();
	energizeroutcome=energy();
	if(energizeroutcome==1)
	{energizerright();}
	}
	
    else if(GetAsyncKeyState(VK_UP)){
    pacmanup();
    energizeroutcome=energy();
	if(energizeroutcome==1)
	{energizerup();}
	}
  
  	else if(GetAsyncKeyState(VK_DOWN)){
    pacmandown();
    energizeroutcome=energy();
	if(energizeroutcome==1)
	{energizerdown();}
	}
  
    else if(GetAsyncKeyState(VK_ESCAPE)){
       gamerunning=false;
	}
	
	else if(maze [ghostX][ghostY]=='P' || maze [ghostvx][ghostvy]=='P' || maze [ghosthx][ghosthy]=='P')
	{ 
       break;
	}
	
	}
	
	cout<<"Game over,Your score :"<<score;

}

//functions


void printmaze()
{
	for(int i=0;i<24;i++)
	{
		for(int j=0;j<71;j++)
		{  
            cout<<maze[i][j];
		}
		cout<<endl;
	}
}


void pacmanleft()
{
    if(maze[pacmanx][pacmany-1]==' ' || maze[pacmanx][pacmany-1]== '.')
    {
        maze[pacmanx][pacmany]=' ';
		gotoxy(pacmany,pacmanx);
		cout<<" ";
        pacmany=pacmany-1;
        if(maze[pacmanx][pacmany]=='.')
        {
        score++;
        }
        gotoxy(pacmany,pacmanx);
		cout<<"P";
    }
}

void pacmanright() 
{
	if(maze[pacmanx][pacmany+1]==' ' || maze[pacmanx][pacmany+1]== '.')
    {
        maze[pacmanx][pacmany]=' ';
		gotoxy(pacmany,pacmanx);
		cout<<" ";
		pacmany=pacmany+1;
        if(maze[pacmanx][pacmany]=='.')
        {
        score++;
        }
        gotoxy(pacmany,pacmanx);
		cout<<"P";
    }
} 


void pacmanup()
{
    
    if(maze[pacmanx-1][pacmany]==' ' || maze[pacmanx-1][pacmany]== '.')
    {
        maze[pacmanx][pacmany]=' ';
		gotoxy(pacmany,pacmanx);
		cout<<" ";
        pacmanx=pacmanx-1;
        if(maze[pacmanx][pacmany]=='.')
        {
        score++;
        }
        gotoxy(pacmany,pacmanx);
		cout<<"P";
    }
	
}

void pacmandown()
{
    if(maze[pacmanx+1][pacmany]==' ' || maze[pacmanx+1][pacmany]== '.')
    {
        maze[pacmanx][pacmany]=' ';
		gotoxy(pacmany,pacmanx);
		cout<<" ";
        pacmanx=pacmanx+1;
        if(maze[pacmanx][pacmany]=='.')
        {
        score++;
        }
        gotoxy(pacmany,pacmanx);
		cout<<"P";
    }
}

void gotoxy(int x,int y) 
{ 
 COORD coordinates; 
 coordinates.X = x; 
 coordinates.Y = y; 
 SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coordinates); 
}

int ghostDirection()
{
    srand(time(0));
    int result = 1 + (rand() % 4);
    return result;
}


bool ghostMovement()
{
    int value = ghostDirection();
    if (value == 1)
    {
        if (maze[ghostX][ghostY - 1] == ' ' || maze[ghostX][ghostY - 1] == '.' || maze[ghostX][ghostY - 1] == 'P')
        {
            maze[ghostX][ghostY] = previousItem;
			gotoxy(ghostY,ghostX);
			cout<<" ";
            ghostY = ghostY - 1;
            previousItem = maze[ghostX][ghostY];
			gotoxy(ghostY,ghostX);
            if (previousItem == 'P')
            {
                collisioncounter++;
				if(collisioncounter>3)
				{return 0;}
            }
			cout<<"G";
        }
    }
    if (value == 2)
    {
        if (maze[ghostX][ghostY + 1] == ' ' || maze[ghostX][ghostY + 1] == '.' || maze[ghostX][ghostY + 1] == 'P')
        {
            maze[ghostX][ghostY] = previousItem;
			gotoxy(ghostY,ghostX);
			cout<<" ";
            ghostY = ghostY + 1;
            previousItem = maze[ghostX][ghostY];
			gotoxy(ghostY,ghostX);
            if (previousItem == 'P')
            {
				collisioncounter++;
				if(collisioncounter>3)
				{return 0;}
            }
            cout<<"G";
        }
    }
    if (value == 3)
    {
        if (maze[ghostX - 1][ghostY] == ' ' || maze[ghostX - 1][ghostY] == '.' || maze[ghostX - 1][ghostY] == 'P')
        {
            maze[ghostX][ghostY] = previousItem;
			gotoxy(ghostY,ghostX);
			cout<<" ";
            ghostX = ghostX - 1;
            previousItem = maze[ghostX][ghostY];
			gotoxy(ghostY,ghostX);
            if (previousItem == 'P')
            {
                collisioncounter++;
				if(collisioncounter>3)
				{return 0;}
            }
			cout<<"G";
           
        }
    }
    if (value == 4)
    {
        if (maze[ghostX + 1][ghostY] == ' ' || maze[ghostX + 1][ghostY] == '.' || maze[ghostX + 1][ghostY] == '.')
        {
            maze[ghostX][ghostY] = previousItem;
			gotoxy(ghostY,ghostX);
			cout<<" ";
            ghostX = ghostX + 1;
            previousItem = maze[ghostX][ghostY];
			gotoxy(ghostY,ghostX);
            if (previousItem == 'P')
            {
                collisioncounter++;
				if(collisioncounter>3)
				{return 0;}
            }
            cout<<"G";
        }
    }
    return 1;
}

void ghostmovement()
{
	
	if(maze[ghostvx][ghostvy]!='#' && maze[ghosthx][ghosthy]!='|')
	{
		maze[ghostvx][ghostvy]=' ';
		gotoxy(ghostvy,ghostvx);
		cout<<" ";
		maze[ghosthx][ghosthy]=' ';
		gotoxy(ghosthy,ghosthx);
		cout<<" ";
	    ghostvx++;
		ghosthy++;
		if(maze[ghostvx][ghostvy]=='#' || maze[ghosthx][ghosthy]=='|')
		{
			ghostvx--;
			ghosthy--;
			
		}
		gotoxy(ghostvy,ghostvx);
		cout<<"G";
		gotoxy(ghosthy,ghosthx);
		cout<<"G";
		
	}
	
}

bool energy()
{
	if(maze[pacmanx][pacmany-1]=='E' || maze[pacmanx][pacmany+1]=='E' || maze[pacmanx-1][pacmany]=='E' || maze[pacmanx+1][pacmany]=='E')
	{
		return 1;
	}
	else
	{
        return 0;
	}		
}

void energizerleft()
{
	if(maze[pacmanx][pacmany-1]==' ' || maze[pacmanx][pacmany-1]== '.' || maze[pacmanx][pacmany-1]=='G')
    {    
    maze[pacmanx][pacmany]=' ';
	gotoxy(pacmany,pacmanx);
    cout<<" ";
    pacmany=pacmany-1;
    if(maze[pacmanx][pacmany]=='.')
    {
    score++;
    }
    gotoxy(pacmany,pacmanx);
	cout<<"P";
	}
}

void energizerright()
{

	if(maze[pacmanx][pacmany+1]==' ' || maze[pacmanx][pacmany+1]== '.' || maze[pacmanx][pacmany+1]=='G') 
    {
        maze[pacmanx][pacmany]=' ';
		gotoxy(pacmany,pacmanx);
		cout<<" ";
		pacmany=pacmany+1;
        if(maze[pacmanx][pacmany]=='.')
        {
        score++;
        }
        gotoxy(pacmany,pacmanx);
		cout<<"P";
    }
	
}

void energizerup()
{
 
    if(maze[pacmanx-1][pacmany]==' ' || maze[pacmanx-1][pacmany]== '.' || maze[pacmanx-1][pacmany]=='G')
    {
        maze[pacmanx][pacmany]=' ';
		gotoxy(pacmany,pacmanx);
		cout<<" ";
        pacmanx=pacmanx-1;
        if(maze[pacmanx][pacmany]=='.')
        {
        score++;
        }
        gotoxy(pacmany,pacmanx);
		cout<<"P";
    }
	
}

void energizerdown()
{
    if(maze[pacmanx+1][pacmany]==' ' || maze[pacmanx+1][pacmany]== '.' || maze[pacmanx+1][pacmany]=='G')
    {
        maze[pacmanx][pacmany]=' ';
		gotoxy(pacmany,pacmanx);
		cout<<" ";
        pacmanx=pacmanx+1;
        if(maze[pacmanx][pacmany]=='.')
        {
        score++;
        }
        gotoxy(pacmany,pacmanx);
		cout<<"P";
    }  
	
}

