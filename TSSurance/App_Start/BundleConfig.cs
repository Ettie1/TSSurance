﻿using System.Web;
using System.Web.Optimization;

namespace TSSurance
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new Bundle("~/bundles/toastrjs").Include(
                      "~/Scripts/toastr.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrapdarkly.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/w3").Include(
                      "~/Content/w3.css"));

            bundles.Add(new StyleBundle("~/bundles/toastrcss").Include(
                      "~/Content/toastr.css"));

            bundles.Add(new StyleBundle("~/bundles/techiestyle").Include("~/Content/techiestyle.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrapcerulean.css",
                      "~/Content/site.css"));


            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
