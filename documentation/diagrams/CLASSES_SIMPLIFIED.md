classDiagram
  direction LR

  class SplashScreenForm
  class LANOptions
  class ConnectionDialog
  class GameForm
  class Game
  class GameState
  class Board
  class Piece
  class Move
  class LANHandler
  class GameLib

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
  Piece <|-- Pawn
  Piece <|-- Rook
  Piece <|-- Knight
  Piece <|-- Bishop
  Piece <|-- Queen
  Piece <|-- King