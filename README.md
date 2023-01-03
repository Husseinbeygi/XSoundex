# Soundex✔️
Soundex is a phonetic algorithm for indexing names by sound, as pronounced in English. The goal is for homophones to be encoded to the same representation so that they can be matched despite minor differences in spelling.
The algorithm mainly encodes consonants; a vowel will not be encoded unless it is the first letter. Soundex is the most widely known of all phonetic algorithms (in part because it is a standard feature of popular database software such as IBM Db2, PostgreSQL, MySQL, SQLite, Ingres, MS SQL Server,Oracle. and SAP ASE.) Improvements to Soundex are the basis for many modern phonetic algorithms. [Source](https://en.wikipedia.org/wiki/Soundex)

# What is Xsoundex✔️
Xsoundex is small .Net library to make usage of this algorithm simpler. The Good Part of this library is that it's language agnostic and with add a new and small changes (like adding a small resource) you can have it in your language!
The result can use the default culture of system, or you provide it explicitly!

# Demo✔️
See the Demo in multilanguage (English and Persian) [HERE](https://husseinbeygi.github.io/soundex-demo/)

# Installation
you can use this [Nuget](https://www.nuget.org/packages/XSoundex/1.0.0)
# How can I use it!✔️
No need for any DI! Just add the nuget package to your project!

1. Generate a code from text : 
```
"Hussein".ToSoundex() // uses the current culture of system

"Hussein".ToSoundex("en-US") // explictly tell the culture
```
2. Provide the soundex code from SQL SERVER!
```
SELECT SOUNDEX("Hussein") // Give you the soundex in your Database

```
You can generate your result in memory on the back-end, or get the result in SQL Server and compare it in your application.
```
lists.Where(x => x.Key == text.ToSoundex())

OR

"Hussein".HasTheSameSoundex("Hossein")

AND 

"Hussein".HasTheSameSoundex("Hossein","en-US")
```

# Contribute✔️

This Algorithm is based on the original algorithm and can be so much better, so:
1. open a Pull Request 🌠
2. give a STAR ⭐ (that would help a lot!)
