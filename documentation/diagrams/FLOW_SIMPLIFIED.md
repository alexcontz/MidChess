flowchart TD
  A["Start"] --> B["SplashScreenForm<br/>Offline / Online (LAN)"]

  B -->|Offline| C["GameForm"]
  B -->|Online| D["LANOptions + ConnectionDialog<br/>connect via LANHandler"]
  D --> C

  C --> E["Render board"]
  E --> F["Click square"]
  F --> G{"Select piece or move?"}

  G -->|Select| H["Highlight legal moves"]
  H --> F

  G -->|Move| I["TryMovePiece(+promotion if needed)"]
  I --> J["Update board + status"]
  J --> K{"Game over?"}
  K -->|Yes| L["End / New game prompt (offline)"]
  K -->|No| E