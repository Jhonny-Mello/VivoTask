# Vivo Task

**[Portfolio Project - Not for Production Use]**

> ⚠️ **Disclaimer: This Code is for Review Only**
>
> The source code in this repository has been intentionally disabled and is **not functional**. All connections to backend services, including Power Automate flows and API endpoints, have been removed for corporate security reasons. This project serves as a portfolio piece to demonstrate architectural patterns (.NET MAUI, MVVM, Blazor Hybrid) and application structure. **It is not intended to be compiled, run, or replicated.**

---

## 📜 About The Project

**Vivo Task** is a cross-platform .NET MAUI application developed for Android and Windows, designed to streamline internal employee assessments and support requests. This application was successfully published to the Google Play Store and Microsoft Store for internal corporate use.

The application serves two primary functions within the corporate environment:

1.  **Employee Assessment:** It empowers authorized leaders to create, customize, and deploy examinations to their subordinates. This tool is designed to identify knowledge gaps and training needs with precision.
2.  **Support Channel:** It provides a direct and efficient communication channel for store-level teams to submit support requests to regional support staff.

The application's architecture is built for security and scalability, leveraging Microsoft's Power Platform to interact with a private corporate network without exposing the backend API directly to the internet.

---

## ✨ Key Features

- **Customizable Exam Creation:** Build tests with a specific number of questions on various topics.
- **Targeted Assessments:** Assign exams to a precise audience, filtering by individual employees, job roles, or entire store locations.
- **Integrated Support Ticketing:** A dedicated module for opening and managing support requests with predefined categories for clarity.
- **Real-time BI Reporting:** Exam results were automatically fed into a Power BI report that refreshed hourly, offering continuous insight into team performance.
- **Cross-Platform:** A single codebase targeting both Android and Windows devices.

---

## 🏗️ Architecture Overview

The application was designed with a decoupled architecture to ensure that the corporate REST API remained secure within the private network. Communication was handled through an intermediary layer of Power Automate flows.

The conceptual data flow was as follows:

**`.NET MAUI App`** ➡️ **`Power Automate Flow (Cloud)`** ➡️ **`On-Premises Data Gateway`** ➡️ **`Corporate Private REST API`**

This setup allowed the mobile and desktop clients to trigger complex backend operations securely.

### Frontend Structure

The frontend is built using **.NET MAUI** and follows the **Model-View-ViewModel (MVVM)** pattern. It employs a hybrid approach for its views:

- **XAML Pages:** Used for primary navigation, menus, and static content pages. These are the standard, compiled views in the MAUI project.
- **Razor Pages:** Used for any view that required interaction with the server (i.e., making requests to Power Automate). This decision was made to leverage and adapt a **pre-existing, fully functional Blazor application**. This strategy allowed for rapid development and reuse of robust, battle-tested components for all data-driven functionalities.

---

## 🚀 Functionality in Detail

### Examination Module

This was the core feature of the application. It allowed managers and team leaders to:

- **Create dynamic exams** based on a wide range of available topics.
- **Define specific parameters** such as the total number of questions.
- **Pinpoint the target audience** for each exam, including specific individuals, employees with certain job titles, or all staff at particular stores.

All scores and results were stored in a central database.

### Support Request System

This module acted as a streamlined communication bridge between store teams and the regional support team.

- It allowed a user to **open a new support ticket** from their device.
- To ensure accuracy and speed up resolution, users could **select from predefined topics and common problems**.
- This created a clear and precise communication channel, reducing back-and-forth and improving response times.

### Power BI Reporting

To close the loop on the examination data, a **Power BI report** was connected to the results database.

- The report provided a comprehensive overview of employee knowledge, highlighting areas of strength and identifying potential gaps.
- It **refreshed on an hourly basis**, giving leadership a near real-time view of performance and allowing for constant evaluation throughout the day.

---

## 🛠️ Tech Stack

- **Frontend:** .NET MAUI, XAML
- **Component Logic:** Blazor (Razor Components)
- **Backend Orchestration:** Microsoft Power Automate
- **Data Gateway:** On-Premises Data Gateway
- **API:** Internal Corporate REST API
- **Reporting:** Microsoft Power BI
- **Design Pattern:** MVVM

---

## 🚀 Getting Started

As stated in the disclaimer, this project is **for review purposes only and cannot be run**. The necessary configurations, such as Power Automate URLs and other sensitive endpoints, have been removed. The code is provided to demonstrate the structure, patterns, and technologies used in the original application.

---

## 📄 License

Distributed under the MIT License. See `LICENSE.txt` for more information.
