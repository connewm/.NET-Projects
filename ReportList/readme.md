# Report List

The Report List project is designed with students in mind, allowing for organization of data associated with research papers/articles/reports etc.

In the future I will be adding functionality for automatic MLA, ALA, etc. citations from user generated Report Lists.
This will also require adding more fields (such as Author, Date Accessed, etc.)

The Report List tool allows users to generate and save Report List (.rlist) files containing multiple Reports, each with data pertaining to
any article or piece of literature. These fields are as follows:

### Title
The title of the work in plaintext

### Subject
The subject to which the work pertains

### Link
A web link to relevant resource (future functionality for multiple web links and user ability to add links)  
The corresponding LinkLabel allows users to access the link  
ReportList handles invalid link exceptions using a Windows Error message  
Eventually, the LinkLabel will redirect to search engine with keyword(s) from web link as search terms  

### File
Ability to attach and access PDF files from ReportList  
Click Browse to attach files  
Click  corresponding LinkLabel to access PDF from web browser  
Handles invalid or non-existent file locations

Files can be accessed from another machine if they are saved within the project folder when they are initially uploaded and saved within the same project folder on the other machine.

I.e. ReportList tries to find the absolute path of the PDF that was initially uploaded and if it can't it chops off all parts of the absolute path up to the project folder and replaces it with current working directory (in this case the project is running out of the project directory.

This means the project directory cannot be renamed, something I will fix in a future iteration.
For example if I upload a project from "C://user/folder/name/ReportList/pdf-name.pdf", and try to access it from another machine from "D://user/some/other/folder/ReportList/pdf-name.pdf", ReportList will turn the filepath into "/ReportList/pdf-name.pdf" and then concat "D://user/some/other/folder" to the front of it, in essence making the filepath relative.

Again, this is rather limiting and will be fixed in a future iteration

### Summary
Rich text box allowing images, links, etc.

### Save
Hitting save will save only the current report to the buffer and add it to the ReportList ListBox 

### Saving A Report List
Hitting File --> Save Works will allow you to save your report list as a .rlist file. The .rlist file can be saved in any directory

### Opening A Report List
File --> Open allows you to open a .rlist file

### Delete
Will delete the currently selected report in the List Box, giving a confirmation with the report name before allowing deletion

### Exiting
Handles two cases. Either the currently opened report hasn't been saved to the report list meaning File --> Save will not save the currently edited report, and the user will be prompted as such before exiting, or the report list as a whole hasn't been saved, generating a different prompt.

Currently ReportList is simply a place to collect articles and research in one singular place, but future improvements will allow for citation generation (which will require more information fields per report) and more versatility in linking external sources to ReportList
