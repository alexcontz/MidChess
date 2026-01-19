classDiagram
  direction LR

  class SplashScreenForm {
    + OnResize(EventArgs)
    + ProcessCmdKey(Message, Keys) bool
    + OnFormClosing(FormClosingEventArgs)
  }

  class LANOptions {
    + HostButton_Click(object, EventArgs)
    + JoinButton_Click(object, EventArgs)
    + LaunchGameForm(LANHandler)
  }

  class ConnectionDialog {
    + ConnectionDialog(int port, char hostColor)
    + ConnectionDialog(string ipAddress, int port)
    + ConnectionDialog_Load(object, EventArgs)
  }

  class GameForm {
    + BoardPanel_Paint(object, PaintEventArgs)
    + BoardPanel_MouseClick(object, MouseEventArgs)
    + ExecuteMove(int,int,int,int)
  }

  class Game {
    + TryMovePiece(int,int,int,int,char) bool
    + UndoLastMove() bool
    + GetLegalMovesForPiece(int,int) List~(int,int)~
  }

  class GameState {
    + SwitchTurn()
    + RecordMove(Move)
    + IsGameOver() bool
  }

  class Board {
    + GetPiece(int,int) Piece
    + PlacePiece(Piece,int,int)
    + MovePiece(int,int,int,int)
  }

  class Piece

  class Move {
    + Move(int,int,int,int,Piece,Piece)
    + ToString() string
  }

  class LANHandler {
    + StartHostingAsync(int,char) Task~bool~
    + JoinGameAsync(string,int) Task~bool~
    + SendMoveAsync(int,int,int,int,char) Task
  }

  class GameLib {
    + RenderBoard(Graphics,Panel,Game,Dictionary~string,Image~,Image,Image,int,int,bool,List~(int,int)~,Color,Color,Color,bool)
    + UpdateMoveHistory(ListView,List~Move~)
    + ShowExportDialog(Game)
  }

  class LANLib {
    + ValidateIPAddress(string,out string,out string) bool
    + ValidatePort(string,out int,out string) bool
    + ValidateStartingColor(bool,bool,out string,out string) bool
  }

  SplashScreenForm --> GameForm : Offline
  SplashScreenForm --> LANOptions : Online
  LANOptions --> ConnectionDialog
  ConnectionDialog --> LANHandler
  LANOptions --> GameForm : starts LAN game

  GameForm --> Game
  GameForm --> GameLib
  GameForm --> LANHandler : optional

  Game --> GameState
  GameState --> Board
  GameState --> Move
  Board --> Piece
  Move --> Piece : moved/captured
  Piece <|-- Pawn
  Piece <|-- Rook
  Piece <|-- Knight
  Piece <|-- Bishop
  Piece <|-- Queen
  Piece <|-- King