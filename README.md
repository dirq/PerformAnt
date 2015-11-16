# PerformAnt
A performance optimized MVC starter project

## Global.asax
BundleTable.EnableOptimizations adds a query string hash to the end of CSS and JS files.  This is triggered by compliation > debug in the web.config.

## web.config
 - http compression (gzip)
 - correct mime types
 - WebMarkupMin for minifying MVC views - see Controllers/HomeController.cs for an example of minifying HTML with a code attribute.
 - Max Age HTTP caching headers

## Views/Shared/_Layout.cshtml
Bundles are set here so they are editible when running locally and debugging

## App_Start/WebApiConfig.cs
Removed XML formatter from WebAPI so we only use JSON
Minify JSON results when not debugging

## Content/site.scss
Refers to Bootstrap SCSS in sass/_custom-bootstrap.scss.  This allows you to only use the portions of Bootstrap that you need.

## Controllers/Shared/CacheControlAttribute.cs
Creates a [CacheControl(MaxAge = 60)] attribute for use on MVC controllers
