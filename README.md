# StutterFix Console Application

**StutterFix** is a .NET 9 console application that uses OpenAI to provide suggestions and fixes for video game stuttering issues. Whether you're a gamer or a developer, this tool offers AI-powered insights to improve performance and gameplay smoothness.

## Features

- Uses OpenAI's GPT models (default: `gpt-4.5-preview`)
- Simple and lightweight command-line interface
- Easily configurable via `appsettings.json` and user secrets
- Low temperature setting (0.2) for more deterministic output

## Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- A valid [OpenAI API key](https://platform.openai.com/account/api-keys)
- Visual Studio (for easiest setup with user secrets)

## Setup Instructions

### 1. Generate an OpenAI API Key

If you haven't already:

1. Go to [https://platform.openai.com/account/api-keys](https://platform.openai.com/account/api-keys)
2. Log in and click **"Create new secret key"**
3. Copy the key – you’ll need it in the next step

### 2. Set Up User Secrets for StutterFix

In Visual Studio:

1. Right-click on the **`StutterFix`** project in Solution Explorer
2. Click **"Manage User Secrets"**
3. In the `secrets.json` file that opens, paste the following (replacing `YOUR_API_KEY_HERE` with your actual key):

```json
{
  "OpenAI": {
    "ApiKey": "YOUR_API_KEY_HERE"
  }
}
