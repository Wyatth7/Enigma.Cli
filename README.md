# Enigma CLI

Enigma is a CLI tool created to encrypt and decrypt files with using AES 16, 24, or 32 byte
encryption. This tool is built within the .NET Core ecosystem, and can be downloaded
and installed using Microsoft's Nuget Package Manager.

This tool is built using the Microsoft Cryptography tools, and can be researched by
looking through their cryptography documentation. No cryptography algorithms have been created from 
scratch here, and there are no plans to implement such algorithms in the future. This is simply
just a tool for quick and simple cryptography functions.

# Downloading Enigma CLI

Downloading Enigma CLI is as simple as installing .NET Core on your system, then
running the following installation command.

`dotnet tool install --global Enigma.Cli --version 1.2.0`

After installing the package, the application should be ready for use. In some instances,
the dotnet tools directory may need to be added to $PATH on your machine.

You can find the Nuget [package here](https://www.nuget.org/packages/Enigma.Cli/).

# How to use

## Commands

### Encrypting file

Encrypting a file is as simple as entering the following.

`enigma encrypt --file=/path/to/file`

Upon running this command, you will be prompted to enter a key used for encryption.
These keys are not stored by Enigma in any way, so be sure to save your encryption key to avoid
data loss or corruption. Once forgotten, the contents of these files can no loner
be recovered.

### Decrypting file

Decrypting a file is as simple as encrypting a file. Just enter the following.

`engima decrypt --file=/path/to/file`

Upon running this command, you will again be prompted to enter a key.
The key used to encrypt the file must be the same key used to encrypt the file. Using
a key different from the one used to encrypt the file will result in a decryption failure.

### Encrypting / Decrypting Recursively

Many times there is a need to encrypt of decrypt many files at once,
this can be accomplished using the recurse command. The recurse command encrypts or decrypts
all files in a directory and any subdirectories with a single given key.

`--recurse` or `-r`

`enigma <encrypt | decrypt> --file=/path/to/directory -r`

# Setting up Enigma CLI for development (advanced)

Although not rocket science to set up and configure, there are several steps to configure Enigma CLI
for local builds and development.

## Download and install .NET Core 9+

Follow [Microsoft's install instructions](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) to setup .NET Core on your system.

## Clone the repository

To start, clone the repository using the following command.

`git clone https://github.com/Wyatth7/Enigma.Cli.git`

## Running the application

Running the application is almost identical to running the production application, however,
development mode has some minor differences in commands / argument structure.

## Executing commands

In a terminal, navigate to the Enigma.Cli project (not to be confused with the Enigma.Cli SLN) on your system.
Run the following command to encrypt or decrypt a file.

`dotnet run <encrypt | decrypt> --file=/path/to/file`

## Using shorthand arguments

In order to use shorthand variants of arguments and not conflict with .NET Core arguments,
you will need to

1. Navigate to one level above the Enigma.Cli project. 
2. Use commands similar to the following

`dotnet run --project Enigma.Cli -- <encrypt | decrypt> -f=/path/to/directory -r`
