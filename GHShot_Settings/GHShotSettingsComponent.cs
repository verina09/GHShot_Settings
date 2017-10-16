using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper.Kernel.Types;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace GHShot_Settings
{
    public class GHShotSettingsComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public GHShotSettingsComponent()
          : base("GHShot_Settings", "GHShot_Settings",
              "Settings Information for GHShots",
              "Connect", "GHShot")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Web Server", "server", "Server Web Address", GH_ParamAccess.item);
            pManager.AddTextParameter("Username", "user", "Username information", GH_ParamAccess.item);
            pManager.AddTextParameter("Project Name", "filename", "Project Name", GH_ParamAccess.item);
            pManager.AddTextParameter("Local Savepath", "localpath", "Save Location in this computer", GH_ParamAccess.item);
        }

        public class Foo
        {
            public string server;
            public string user;
            public string filename;
            public string localpath;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Settings", "S", "Settings information for GHShots", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //get all inputs

            String[] settings = new String[4];
            DA.GetData<string>("Web Server", ref settings[0]);
            DA.GetData<string>("Username", ref settings[1]);
            DA.GetData<string>("Project Name", ref settings[2]);
            DA.GetData<string>("Local Savepath", ref settings[3]);

            List<string> settings_output = new List<string>();
            for (int i = 0; i < settings.Length; i++)
            {
                settings_output.Add(settings[i]);
            }
            DA.SetDataList(0, settings_output);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                return GHShot_Settings.Properties.Resources.settings_icon;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("401726f6-876c-40a9-be98-08814d6bf4ad"); }
        }
    }
}
