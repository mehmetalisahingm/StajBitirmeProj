# Smart Home Monitoring Prototype (HomeAssis)

A Windows desktop application developed during my first software engineering internship at RSA Siber Güvenlik Teknolojileri (June–July 2025, 20 working days).

## Overview

The prototype simulates temperature, humidity, door-state and smoke readings, stores them in SQLite, and displays sensor records and threshold violations in a Windows Forms interface.

## Technical highlights

- C# and .NET 8 with Windows Forms.
- Background thread generating simulated sensor readings periodically.
- SQLite persistence for sensor records, alarms and configurable thresholds.
- Conditional highlighting of readings that exceed their configured thresholds.
- User interface for managing sensor columns, thresholds and stored records.

## Architecture

```
Simulated sensors → background worker → SQLite → Windows Forms monitoring UI
                                       └─────→ threshold-based alarm records
```

## Running the prototype

Open `HomeAssis.sln` in Visual Studio with the .NET desktop development workload on Windows. Restore NuGet dependencies. Before running, update the local SQLite connection paths in `Form1.cs` and `Sensorler.cs` to point at a local development database with the expected schema. Use a disposable test database, since the UI includes data-clearing and schema-editing operations.

## Scope and limitations

This is an internship learning prototype, not a production home-safety system. Sensor readings are simulated, not collected from physical hardware. The historical implementation uses machine-specific database paths and requires local configuration; automated tests and a portable database setup have not been verified.

## Author

Mehmet Ali Şahin · [Portfolio](https://mehmetalisahingm.github.io/) · [GitHub](https://github.com/mehmetalisahingm)
