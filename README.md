# DeviceInsight

WPF-Based Windows Desktop Application (.NET 10) for Advanced Hardware Monitoring and Analysis Beyond Native Device Metrics.

## Features

- **Home Dashboard** - Quick navigation to device insights
- **Battery Health Monitoring** - Detailed battery status and health information
- **Modern UI** - Clean, responsive user interface with navigation support
- **MVVM Architecture** - Well-structured codebase using the Model-View-ViewModel pattern

## Tech Stack

- **Framework:** .NET 10
- **UI Framework:** WPF (Windows Presentation Foundation)
- **Language:** C#
- **Architecture:** MVVM (Model-View-ViewModel)

## Project Structure

```
DeviceInsight/
├── App.xaml						# Application resources and startup 
├── MainWindow.xaml					# Main application window
├── Models: DeviceInsightModel.cs	# Model class
├── Views/ 
│   ├── Home.xaml					# Home view
│   └── BatteryHealth.xaml			# Battery health info view 
└── ViewModels/ 
	└── BatteryHealthViewModel.cs	# logic to fetch battery data
```

## Getting Started

### Prerequisites

- .NET 10 SDK or later
- Visual Studio 2026 or later
- Windows 10/11

### Installation

1. Clone the repository
2. Open the solution in Visual Studio
3. Build and run the application

---

**Note:** This project is currently under development. Features and functionality may change.