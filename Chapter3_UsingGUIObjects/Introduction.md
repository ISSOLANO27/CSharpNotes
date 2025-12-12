# Chapter Introduction
You have learned to write a simple C sharp programs that accept input from a user at the console and produce output at the command line. The environment the user sees is a programs interface. Unfortunately, the interfaces in the applications you have written so far look dull. Most modern applications use visually pleasing graphic objects to interact with users. These graphical user interfaces (GUI) objects, include the labels, buttons, and text boxes you manipulate or control with a mouse, touch screen or keyboard when interacting with Windows-type programs.

In chapter one you learn that that when you write a console application, you can use a simple text editor such as Notepad or you can use the Visual Studio Integrated development environments (IDE). Technically you have the same options when you write a GUI program. However, so much code is needed to create even the simplest of GUI programs that it is far more practical to develop the user interface visually in the IDE. This approach allows the IDE to automatically generate much of the code you need to developing appealing GUI programs that are easy to use.
In Visual Studio versions before NET, CC and Visual Basic each had its own IDE, so you had to learn about a new environment with each programming language you studied. Now you can use 188 to create projects in all the supported languages.

# 3-1 Creating Forms in the IDE
**Forms** are rectangular GUI objects that provide an interface for collecting, displaying, and delivering information. Although they are not required, forms almost always include **controls**, which are devices such as labels, text boxes, and buttons that users can manipulate to interact with A program. The C Sharp class that creates a form is **Form**. To create a form visually using the IDE you start Visual Studio, select _File_ from the main menu, then _New_ and _Project_ and then choose _Windows Forms App_ as shown in the figure below. By default, Visual Studio names your first forms application Windows Form App 1. You can change the name if you want, and you can browse and choose a location to save the application. You should almost always provide a more meaningful name for applications than the default name suggested. Most of the examples in this chapter retain the default names from minimize the number of changes required if you want to replicate the steps on your computer.

After you click OK in the new project window, you see the IDE main window as shown in Figure 32. The main window contains several smaller windows, each of which can be resized, relocated, or closed. If a window is not currently visible, you can select it from the View menu in the menu bar. Some key features in the IDE follow.
- The name of the project shown in three places; on the title bar, and in 2 locations in the Solution explorer. In the Figure 32, the application has the default name WindowsFormApp1.
- The menu bar which lies horizontally across the top of the window and includes a file menu from which you open, close and save projects. It also contains sub menus for editing, debugging and help tasks among others.

As you work through any project, you should choose Save All frequently. You can select this axiom from the File menu or click the Save All button, which has an icon that looks like 2 overlapping disks.

- The Toolbox tab which when opened provides list of controls you can drag onto a form so that you can develop programs visually using a mouse or touchpad.

- The form designer which appears in the center of the screen. This is where you design applications visually.

- the _Solution Explorer_ for viewing and managing project files and settings.

- The _Properties_ window for configuring properties and events on controllers in your user interface. For example, you can use this window to set the **Size** property of a **Button** or the **Text** property of a **Form**.

- The _Error_ List, which displays any warnings and errors that occur when you build or execute a program.

If some of these features are not visible after you start a project in the IDE, you can select them from the View menu.

 The Solution Explorer file list shows the files that are part of the current project at the program. CS file contains the automatically generated main () method of the application. And the Form 1CS file contains other automatically generated code and is where you write code describing the task you will assign to controls in your application.

 To the left of some of the items in the Solution Explorer, you see a small triangle node. A **node** is an icon that can be used to expand or condense a list or a section of code. (in Visual Studio some nodes appear as triangles and others appear as small plus or minus signs) When a triangle shaped node appoints straight to the right, you see a condensed view. Clicking the triangle reveals hidden items or code. The triangle will point diagonally down and to the right and you see all the items in the list (or all the hidden code or) Clicking the triangle again collapse.... you can work with a condensed view 
 Clicking the triangle again collapses the list so you can work with a condensed view Clicking the triangle again collapses the list so you can work with a condensed view
 If you expand to form One CS note by ....ou could easily corrupt the program 
IIf you expand to Form 1CS note by clicking it, you see a file named 41 Designer CS. The Windows Form designer automatically writes code in the designer CS file. The code created there implements all the actions that are performed when you drag and drop controls from the toolbox. You avoid making manual changes on the file because you could easily corrupt the program
When you create a window form project, the visual C adds a form to the project and calls it Form 1. After you click the form in the form designer area, you can see the name of the form in the following locations.

- On the Folder tab at the top of the Form designer area (followed by [_design_])
- In the title bar of the form in the form designer area.
- In the Solution Explorer file list. (with a .cs ectension) 
- (with a dot, CS extension) 
- (with a.Cs extension) (with a.Cs extension)
- At the top of the properties window indicating that the property listed are for Form1
- As the contents of the Text property listed within the Properties window.

You can scroll through a list of properties the property window. For example, Size, text and fonts are listed if you click a property. A brief description of it appears at the bottom of the Properties window.