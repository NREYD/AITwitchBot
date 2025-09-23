# 🎮 AI-Powered Twitch Bot (with Ollama)

This is a simple yet customizable **AI Twitch Bot** powered by **[Ollama](https://ollama.com/)**.  

You can easily tailor the bot’s behavior by editing:
- **Prompt (~ line 65)** – Controls how the bot responds.  
- **Call messages (~ line 49)** – Defines when and how the bot replies.  

While most of the setup is already done, a few prerequisites are required before running the bot.  

---

## 📦 Prerequisites

### 1. Install Visual Studio (Optional but Recommended)
While **Visual Studio** isn’t strictly required, it makes managing dependencies with **NuGet** much easier.  

👉 Download here: [Visual Studio Community Edition](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)

---

### 2. Install Ollama
This project uses **Ollama** as the AI engine because:
1. It’s free (no need for a ChatGPT API key).  
2. It offers a wide variety of models.  

👉 Download here: [Ollama Download](https://ollama.com/download)  

For this bot, I’m using **`llama3.1`**, but you can choose any model you like.  

To set up your model:
1. Visit the [Ollama Model Library](https://ollama.com/library).  
2. Pick a model you want to use.  
3. Copy the provided `ollama run <modelname>` command.  
4. Run it in your terminal (e.g. `ollama run llama3.1`).  
5. If you use a different model, update the bot’s code:  
   - Go to **~ line 64** and change `"llama3.1"` to your chosen model.  
6. Wait for the model to finish downloading.  

Finally, install the **OllamaSharp** package via NuGet (explained below).  

---

### 3. Install OllamaSharp (via NuGet)
OllamaSharp is the C# library that connects your bot to Ollama.  

Steps to install:
1. In Visual Studio, go to **Project → Manage NuGet Packages**.  
2. Open the **Browse** tab and search for `OllamaSharp`.  
3. Click **Install**.  
4. Done ✅  

---

### 4. Bot Setup

Almost finished! Now you just need to configure your **Twitch credentials** and **prompt**.

#### 🔑 Get Your Twitch OAuth Token
1. Go to [Twitch OAuth Generator](https://twitchapps.com/tmi/).  
2. Click **Connect** and authorize.  
3. Copy the **entire** OAuth token (including `oauth:`).  
   - Example: `oauth:tqw7k7vnwa76vk9kgaifj98gtdkj65g`  
4. Replace `oauthhere` on **~ line 19** with your token.  

#### 👤 Set Your Bot Username
- Use the Twitch username associated with your OAuth token.  
- Must be **lowercase**.  
- Update this on **~ line 20**.  

#### 🧠 Customize the Prompt
- Go to **~ line 65**.  
- Replace only the `(insert prompt here)` section with your custom prompt.  
- Keep the other parts intact (they prevent the bot from replying with “Sure, I can generate…” filler text).  

---

## 🚀 Running the Bot
Once everything is set up, run the bot. You should see messages like:

:tmi.twitch.tv 001 test :Welcome, GLHF!
:tmi.twitch.tv 002 test :Your host is tmi.twitch.tv
:tmi.twitch.tv 003 test :This server is rather new
:tmi.twitch.tv 004 test :-
:tmi.twitch.tv 375 test :-
:tmi.twitch.tv 372 test :You are in a maze of twisty passages, all alike.
:tmi.twitch.tv 376 test :>


If you see this, your bot is connected and ready to chat on Twitch 🎉  

---

## 🎯 Summary
- **Highly customizable** (just edit lines ~49 and ~65).  
- **Free & flexible AI** thanks to Ollama.  
- **Simple setup** with Visual Studio + NuGet.  

Now your AI Twitch Bot is live — have fun! 🚀  
