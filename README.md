## This is repository is a template for a platform in [fnbot.shop](https://github.com/fnbot-shop)

### Prerequisites
For now, .NET Core 3.1 is required in order to generate a `.fnp` file. This requirement may be removed in the future.

# Basic Terminology
 - Plugin: Either a module or a platform, depending on what it's describing
 - Module: A module supplies items for its corresponding platforms to post
 - Platform: A platform takes in items from a module and posts it to some arbitrary location. Ideally, this location is on social media, or some other place like a webhook or an HTTP server
 - Item: An item can be any type of multimedia (text, image, gif, video) that is created by a module and posted by a platform

# Setup

 1. First, you need to create a repository for your platform. The easiest way is to click the green "**Use this template**" button and follow the instructions there to create your own repository for you to modify. For further help, click [here](https://help.github.com/en/github/creating-cloning-and-archiving-repositories/creating-a-repository-from-a-template).
 2. Next, you'll need to clone your repository over to your local computer. If you don't know how to do that, see [this article](https://help.github.com/en/github/creating-cloning-and-archiving-repositories/cloning-a-repository).

# Layout
Your repository has multiple necessary files. Let's take it step by step:

 - `plugin.json`
This JSON file is required by the plugin creator to create a valid `.fnp` plugin for fnbot.shop to use. Here's the general layout:

       {
         "name": "Base Platform",                    // Name of the plugin. If you are signing it, make sure the certificate name is the same
         "description": "Just a test platform",      // Description
         "version": "1.0",                           // Can be basically anything, but semantic versioning is reccomended
         "guid": "e860933b256c41c78688cd03d8bae783", // A random guid that must be unique under all circumstances (GUIDs are unique 32 character hex strings)
         "main": "BasePlatform.BasePlatform",        // The class of the plugin (includes namespace and full class name)
         "type": "platform",                         // Platforms need to keep this at "platform"
         "verify": true,                             // If you are signing, you need to have cert.crt and cert.fnprv
         "pdb": true                                 // Include the PDB file for a better stacktrace with line numbers
       }
- `icon.png`
This PNG file is used as an icon for your plugin and is required. It must be at least 128x128 and at most 512x512.
- `cert.fnc`
This certificate is used for signing the plugin. You can publicly share this certificate file with anyone, you aren't endangering yourself. This file is only required if `verify` in `plugin.json` is set to `true`.
- `cert.fnprv`
This *private key file* is used for signing the plugin as well. You must not share this certificate with anyone (you should hide it in your `.gitignore` file). This file is only required if `verify` in `plugin.json` is set to `true`.

# Signing and Certificates
If you want to verify your plugin and get a little checkmark on your plugin, follow the instructions below. Signing and verification prevents your plugin from being modified and being able to run, so your code is guaranteed to not be malicious.

 1. You can apply for verification [here](https://forms.gle/8tg4FGNhNG9BkHDcA). (Currently closed)
 2. Once you have the `.fnc` and `.fnprv` files, copy them to your base directory. Make sure your `.fnprv` file is excluded in your `.gitignore` file if you're planning on publicizing your repository.

**Note: If your verified plugin is perceived malicious, your certificate will be revoked, causing all future, current, and past versions of your plugin to be unable to run.**