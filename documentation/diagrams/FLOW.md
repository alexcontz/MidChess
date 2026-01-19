flowchart TD
  A["Start MidChess"] --> B["Program.Main()"]
  B --> C["SplashScreenForm<br/>- Offline<br/>- Online (LAN)<br/>- Fullscreen / Exit"]

  C -->|Offline| D["GameForm (offline)"]
  C -->|Online| E["LANOptions -> ConnectionDialog -> LANHandler"]

  D --> F["new Game() + LoadImages()"]
  F --> G["Render board (GameLib.RenderBoard)"]

  G --> H["Click on board"]
  H --> I["Select piece -> compute legal moves"]
  I --> J["Choose destination square"]
  J --> K{"Promotion?"}
  K -->|Yes| L["Promotion dialog (Q/R/B/N)"]
  K -->|No| M["Default Q"]
  L --> N["TryMovePiece(...)"]
  M --> N["TryMovePiece(...)"]

  N --> O{"Move accepted?"}
  O -->|Yes| P["UpdateBoard + Show status"]
  O -->|No| Q["Deselect"]

  P --> R{"Game over?"}
  R -->|Yes| S["TryNewGame (offline only)"]
  R -->|No| G

  E --> T["GameForm (LAN)"]
  T --> U["Send/Receive moves via LANHandler"]
  U --> G