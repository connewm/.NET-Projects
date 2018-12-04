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
Handles invalid or non-existent
