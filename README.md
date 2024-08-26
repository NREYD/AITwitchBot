 This is a simple AI Twitch bot powered by Ollama

 This bot is highly (and easly) changeable to your likings, by editing the prompt (~ Line 65) and call messages (~ Line 49)

While this bot is mostly finsished for you, there are some prerequisite that need to be done before hand

1. Visual Stuido download 
    While Visual Studio is techincly not needed, it makes downloading packages via NuGet that you will need down the road alot easier. Visual Studio can be downloaded here -> https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false

2. Ollama download
    For this project we will be using Ollama as our AI, 
        1. beacuse im broke and cant pay for the ChatGPT API
        2. beacuse its got alot of different models you can choose from
    Ollama can be downloaded here -> https://ollama.com/download

    For this project I'll be using LLama3.1, but you can use whatever Model you would like.
    Once ollama has been downloaded and you have set it up on your computer the last step is to choose your model,
    as ive said before ill be using Ollama3.1, but if you want to use a different model you need to:
        1. go to https://ollama.com/library
        2. select the Model you want to use
        3. copy the command that is on the screen and paste (or type) it into a command prompt 
        (in my case i will be using: ollama run llama3.1)
        4. while downloading you will need to change the model in the code (if you didnt use llama3.1) to change the model:
            1. go to line ~64 in the code
            2. change "llama3.1" to the name of your model
        5. wait for the download to finish for the model
    once you have done that step, you will need to download the OllamaSharp package via NuGet (this is why we use Visual Studio noobs)

3. Download OllamaSharp in Visual Studio:
    For Ollama to work with C# we need to download OllamaSharp, to do this we:

    1. Click on project, then click Manage NuGet Plugins
    2. once your in the menu click on Browse then type 'OllamaSharp' into the searchbar
    3. install the package, then your finished
    
4. Setting up the code correctly

    Your nearly finsihed setting up the bot! all you have left to do is getting your oauth token, putting in the correct info, then setting up the prompt for your bot

    1. Getting your oauth token

        to get your oauth token you have to:
            1. go to https://twitchapps.com/tmi/ and click connect
            2. click authorize on the pop-up
            3. copy the ENTIRE oauthtoken which includes the oauth: at the start, your oauth token should look something like this: oauth:tqw7k7vnwa76vk9kgaifj98gtdkj65g
            4. once you have this token, replace it with the 'oauthhere' on ~ line 19
        
        to get your botusername just take the name of the account you linked the oauth to (remember this has to be all lowercase) this is on ~ line 20

        to change the prompt, go to ~ line 65 and only change the part that says (insert prompt here) the other stuff is there so the bot doesnt start with all the "Sure, I can generate" bloo blah



After this the bot should be all set up! congrats

when you run the bot you should see in the console:

:tmi.twitch.tv 001 test :Welcome, GLHF!
:tmi.twitch.tv 002 test :Your host is tmi.twitch.tv
:tmi.twitch.tv 003 test :This server is rather new
:tmi.twitch.tv 004 test :-
:tmi.twitch.tv 375 test :-
:tmi.twitch.tv 372 test :You are in a maze of twisty passages, all alike.
:tmi.twitch.tv 376 test :>
            

    
    