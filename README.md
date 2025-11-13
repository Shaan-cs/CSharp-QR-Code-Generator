# C#-QR-Code-Generator
QR Code Generator (C# / WPF) A simple and lightweight desktop application built using C# and WPF (.NET) that allows users to quickly generate high-quality QR codes from any text, URL, email, or custom data. The application provides a clean UI, real-time QR preview, and the ability to save generated QR codes as image files.

💡 QR Code Generator

🌟 Project Overview

QR Code Generator Pro is a high-quality desktop application built on the modern WPF (Windows Presentation Foundation) framework. The application's core purpose is to elevate standard QR code generation by providing a Luxury Dark-Mode UI and advanced customization features, such as gradient coloring and logo embedding.

This project involved migrating the legacy WinForms solution to a stable, advanced WAML/C# solution to achieve a highly modern user experience.

🚀 Key Features

Luxury UI: A modern, responsive dark-mode interface designed using XAML Styles for a superior user experience.

Multi-Payload Generation: Supports structured output for complex data formats:

WiFi: Generates QR codes that allow devices to connect instantly.

Contact (vCard): Creates vCard formats for quick contact saving on phones.

Email: Formats mailto: links with predefined subject and body.

Aesthetic Rendering: Custom C# logic applies a unique Purple-to-Blue Linear Gradient directly onto the QR code matrix.

Center Overlay: Provides the capability to embed Text or Company Logos in the center of the QR code, with automatic enforcement of High Error Correction (Level H) to ensure scan-ability.

Quality Control: Options to select output resolution (up to 2000x2000) and Error Correction Level (L, M, Q, H).

Easy Export: One-click functionality to Save (PNG/JPG) or Copy the generated image to the system Clipboard.

🛠️ Technology Stack

Component

Technology

Role

Framework

C# (.NET 8.0)

Core logic and data formatting.

User Interface

WPF / XAML

Hardware-accelerated presentation layer for the modern UI.

Encoding

ZXing.Net

Fast and reliable QR code encoding library.

Rendering

System.Drawing

Used for custom gradient and logo placement.

⚙️ Setup and Running the Project (Visual Studio 2022)

Prerequisites

Visual Studio 2022: (Community Edition is free).

Required Workloads: The .NET desktop development workload must be installed.

1. Project Restoration

Open Visual Studio 2022.

Click "Open a project or solution" and select the QRCodeGeneratorWPF.csproj file.

Visual Studio will automatically Restore all necessary NuGet packages.

2. Launch Application

In the Visual Studio toolbar, press F5 or click the green Start button.

The application will launch in a maximized window with the Luxury UI.

🐛 Troubleshooting (Common Issues)

InitializeComponent Error: This usually occurs when project files are out of sync. To fix, manually delete the bin and obj folders from the project directory and then perform a Rebuild Solution.

Silent Fail: If the app builds but does not launch, ensure your App.xaml file has StartupUri="MainWindow.xaml" correctly set.

## Output Preview<img width="1920" height="1080" alt="Screenshot (196)" src="https://github.com/user-attachments/assets/b8fbee09-f103-4724-ad1b-c527c30765ef" />




