
# **📘 Chapter 14 — Files and Streams**



## **Table of Contents**

  [Introduction](#introduction)

1. [Files and the File and Directory Classes](#files-and-the-file-and-directory-classes)

   * [Using the File and Directory Classes](#using-the-file-and-directory-classes)
   * [Understanding File Data Organization](#understanding-file-data-organization)
   * [Understanding Streams](#understanding-streams)

2. [Writing and Reading a Sequential Access File](#writing-and-reading-a-sequential-access-file)

   * [Writing Data to a Sequential Access Text File](#writing-data-to-a-sequential-access-text-file)
   * [Reading from a Sequential Access Text File](#reading-from-a-sequential-access-text-file)
   * [Searching a Sequential Text File](#searching-a-sequential-text-file)
   * [Understanding Serialization and Deserialization](#understanding-serialization-and-deserialization)

3. [Chapter Summary](#chapter-summary)

4. [Key Terms](#key-terms)

5. [Review Questions](#review-questions)

6. [Exercises](#exercises)


<br>
<br>
<br>



# Introduction

Upon completion of this chapter, you will be able to:

* Describe computer files and the File and Directory classes
* Describe file data organization
* Describe streams and how they move data
* Write to and read from a sequential access text file
* Search a sequential access text file
* Understand serialization and deserialization

In earlier chapters, programs lived entirely in memory: flexible, fast, but temporary. Once the program ended, everything vanished. Files change that. They allow your applications to persist data across sessions, store information long-term, and communicate with the outside world.
This chapter introduces how C# interacts with a computer’s file system, how data is organized inside files, and how streams serve as the channels through which information flows in and out.



