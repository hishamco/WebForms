# WebForms
ASP.NET Core Web Forms is MVC alternative that use event-driven programming for building dynamic web application

### What is this?
This is just a prototype for building a new programming model for ASP.NET Core (alternative for MVC), that use event-driven programming. It's simillar to previous ASP.NET Web Forms that we know and love, with new flavour 

### What are the plans for this project?
The project is still in the early stages, but I have some points in my mind to share:
- Building a basic infrastructure for Web Forms on top new Http pipline using `Middleware`
- Page Lifecycle is not like the previous ASP.NET WebForms
- Provide a set of rich server controls that render a clean HTML markup, without wired IDs
- No `ViewState` anymore
- No View Engine yet!! it's a pure HTML page with rich server controls, perhaps we can use `Razor` or any other view engine later on, but I'm thinking to use sort of client-side template language like `Mustache`

### Why are Web Forms using .htm, .htm.cs instead of .aspx, .aspx.cs?
There's no primary reason for that, but I want to take the advantages for VS intellisense while I'm using HTML views for now. For the release may I use the `.aspx` or `.aspc` while we're using ASP.NET Core.

### Can I use it in Production?
Short answer is **Not Yet**, because the project is still a prototype, and it's under development. All of you 're welcome to contribute to the source code, to bring ASP.NET WebForms back.