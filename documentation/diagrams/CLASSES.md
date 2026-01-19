classDiagram
  direction LR

  %% ===== UI Layer =====
  class Program {
    + Main()
  }

  class SplashScreenForm {
    + bool isFullscreen
    + SplashScreenForm()
    - OnlineButton_Click(object, EventArgs)
    - OfflineButton_Click(object, EventArgs)
    - FullScreenButton_Click(object, EventArgs)
  }

  class LANOptions {
    + bool isFullscreen
    - FormLib formLib
    - LANLib lanLib
    - SplashScreenForm splashScreen
    + LANOptions(SplashScreenForm)
    - HostButton_Click(object, EventArgs)
    - JoinButton_Click(object, EventArgs)
    - LaunchGameForm(LANHandler)
  }

  class ConnectionDialog {
    - LANHandler lanHandler
    + bool ConnectionSuccessful
    + LANHandler LANHandler
  }

  class GameForm {
    + bool isFullscreen
    - bool isBoardFlipped
    - FormLib formLib
    - GameLib gameLib
    - LANLib lanLib
    - GameDialog gameDialog
    - SplashScreenForm splashScreen
    - LANHandler lanHandler
    - Game game
    - int selectedX
    - int selectedY
    - bool isPieceSelected
    - List~(int x,int y)~ legalMoves
    + GameForm(SplashScreenForm, LANHandler)
    - BoardPanel_Paint(object, PaintEventArgs)
    - BoardPanel_MouseClick(object, MouseEventArgs)
    - HandleSquareClick(int,int)
    - SelectPiece(int,int)
    - Deselect()
    - ExecuteMove(int,int,int,int)
    - ShowPromotionDialog() char
    - UpdateBoard()
    - CheckGameStatus()
  }

  %% ===== Game/Logic Layer =====
  class Game {
    + GameState GameState
    + Game()
    + TryMovePiece(int,int,int,int,char) bool
    + UndoLastMove() bool
    + GetLegalMovesForPiece(int,int) List~(int,int)~
    + GetTrulyLegalMoves(int,int) List~(int,int)~
    + IsPromotionMove(int,int,int,int) bool
    + PromotePawn(int,int,char,char)
    + GetGameStatus(char) GameStatus
    + IsKingInCheck(char) bool
  }

  class GameState {
    <<state>>
    + Board Board
    + char CurrentTurn
    + List~Move~ MoveHistory
    + int MoveCount
    + GameStatus Status
    + SwitchTurn()
    + IsValidTurn(char) bool
    + RecordMove(Move)
    + GetLastMove() Move
    + IsGameOver() bool
  }

  class Board {
    + Piece[,] BoardMatrix
    + int Size
    + IsOnBoard(int,int) bool
    + IsEmpty(int,int) bool
    + GetPiece(int,int) Piece
    + PlacePiece(Piece,int,int)
    + MovePiece(int,int,int,int)
  }

  class Move {
    + int FromX
    + int FromY
    + int ToX
    + int ToY
    + Piece MovedPiece
    + Piece CapturedPiece
    + string Disambiguation
    + Move(int,int,int,int,Piece,Piece)
    + ToString() string
  }

  class Piece {
    <<abstract>>
    + char Color
    + bool HasMoved
    + Piece(char)
    + GetLegalMoves(Board,int,int) List~(int,int)~
  }

  class Pawn {
    + Pawn(char)
    + GetLegalMoves(Board,int,int) List~(int,int)~
    + GetLegalMoves(Board,int,int,Move) List~(int,int)~
  }

  class Rook {
    + Rook(char)
    + GetLegalMoves(Board,int,int) List~(int,int)~
  }

  class Knight {
    + Knight(char)
    + GetLegalMoves(Board,int,int) List~(int,int)~
  }

  class Bishop {
    + Bishop(char)
    + GetLegalMoves(Board,int,int) List~(int,int)~
  }

  class Queen {
    + Queen(char)
    + GetLegalMoves(Board,int,int) List~(int,int)~
  }

  class King {
    + King(char)
    + GetLegalMoves(Board,int,int) List~(int,int)~
  }

  %% ===== Networking + Helpers =====
  class LANHandler {
    + bool IsHost
    + bool IsConnected
    + char LocalPlayerColor
    + StartHostingAsync(int,char) Task~bool~
    + JoinGameAsync(string,int) Task~bool~
    + SendMoveAsync(int,int,int,int,char) Task
    + SendDrawOfferAsync() Task
    + SendTakebackOfferAsync() Task
    + SendResignAsync() Task
    + ResignAndDisconnectAsync() Task
    + DisconnectAsync() Task
    + IsLocalPlayerTurn(char) bool
    + IsLocalPlayerPiece(char) bool
    + CanSelectPiece(char,char) bool
  }

  class MoveReceivedEventArgs {
    + int FromX
    + int FromY
    + int ToX
    + int ToY
    + char Promotion
  }

  class GameLib {
    + LoadPieceImages() Dictionary~string,Image~
    + LoadSquareImages(out Image,out Image)
    + RenderBoard(Graphics,Panel,Game,Dictionary~string,Image~,Image,Image,int,int,bool,List~(int,int)~,Color,Color,Color,bool)
    + UpdateMoveHistory(ListView,List~Move~)
    + ShowGameStatusMessage(GameStatus,char)
    + ShowExportDialog(Game)
  }

  class GameDialog {
    + ShowDrawOfferReceivedDialog() bool
    + ShowDrawOfferSentMessage()
    + ShowDrawAcceptedMessage()
    + ShowOpponentAcceptedDrawMessage()
    + ShowDrawDeclinedMessage()
    + ShowTakebackOfferReceivedDialog() bool
    + ShowTakebackOfferSentMessage()
    + ShowTakebackAcceptedMessage()
    + ShowOpponentAcceptedTakebackMessage()
    + ShowTakebackDeclinedMessage()
    + ShowResignConfirmation() bool
    + ShowResignationMessage()
    + ShowOpponentResignedMessage()
    + ShowOpponentDisconnectedMessage()
    + ShowLeaveGameConfirmation() bool
    + ShowReturnToMenuDialog() bool
  }

  class LANLib {
    + ValidateIPAddress(string,out string,out string) bool
    + ValidatePort(string,out int,out string) bool
    + ValidateStartingColor(bool,bool,out string,out string) bool
  }

  class FormLib {
    + ApplyAll(Form)
    + ToggleFullscreen(Form, ref bool)
    + ConfirmExit() bool
    + ShowConfirmDialog(string,string) bool
    + ShowInfoMessage(string,string)
  }

  %% ===== Relationships =====
  Program --> SplashScreenForm
  SplashScreenForm --> GameForm : "Offline"
  SplashScreenForm --> LANOptions : "Online"

  LANOptions --> ConnectionDialog
  ConnectionDialog --> LANHandler
  LANOptions --> LANLib
  LANOptions --> FormLib
  LANOptions --> SplashScreenForm

  GameForm --> Game
  GameForm --> GameLib
  GameForm --> GameDialog
  GameForm --> LANHandler : "optional"
  GameForm --> FormLib
  GameForm --> LANLib
  GameForm --> SplashScreenForm

  Game --> GameState
  GameState --> Board
  GameState --> Move
  Board --> Piece

  Piece <|-- Pawn
  Piece <|-- Rook
  Piece <|-- Knight
  Piece <|-- Bishop
  Piece <|-- Queen
  Piece <|-- King

  Move --> Piece : "MovedPiece/CapturedPiece"
  LANHandler --> MoveReceivedEventArgs : "OnMoveReceived"
  GameLib --> Game
  GameLib --> Move