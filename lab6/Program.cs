using System;
using NXOpen;
using NXOpen.UF;

public class Program
{
    // class members
    private static Session theSession;
    private static UI theUI;
    private static UFSession theUfSession;
    public static Program theProgram;
    public static bool isDisposeCalled;

    //------------------------------------------------------------------------------
    // Constructor
    //------------------------------------------------------------------------------
    public Program()
    {
        try
        {
            theSession = Session.GetSession();
            theUI = UI.GetUI();
            theUfSession = UFSession.GetUFSession();
            isDisposeCalled = false;
        }
        catch (NXOpen.NXException ex)
        {
            // ---- Enter your exception handling code here -----
            // UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Error, ex.Message);
        }
    }

    //------------------------------------------------------------------------------
    //  Explicit Activation
    //      This entry point is used to activate the application explicitly
    //------------------------------------------------------------------------------
    public static int Main(string[] args)
    {
        int retValue = 0;
        try
        {
            theProgram = new Program();

            //TODO: Add your application code here 
            Tag UFPart;
            string part_name = "Cylindr";
            int units = 1;
            theUfSession.Part.New(part_name, units, out UFPart);
            Tag parent_part = theUfSession.Part.AskDisplayPart();
            UFPart.LoadStatus error_status, error_status2, error_status3;
            Tag instance, instance1, instance2;
            double[] origin1 = { 200, 0, 0 };
            double[] matrix1 = { 1, 0, 0, 0, 1, 0 };
            double[] origin2 = { 0, 0, 0 };
            double[] matrix2 = { 1, 0, 0, 0, 1, 0 };
            double[] origin3 = { -10, 0, 0 };
            double[] matrix3 = { 1, 0, 0, 0, 1, 0 };
            theUfSession.Assem.AddPartToAssembly(parent_part, "model1", null, null, origin1, matrix1, 0, out instance, out error_status);
            theUfSession.Assem.AddPartToAssembly(parent_part, "model2",null, null, origin2, matrix2, 0, out instance1, out error_status2);
            theUfSession.Assem.AddPartToAssembly(parent_part, "model3", null, null, origin3, matrix3, 0, out instance2, out error_status3);
            theUfSession.Part.Save();
            theProgram.Dispose();
        }
        catch (NXOpen.NXException ex)
        {
            // ---- Enter your exception handling code here -----

        }
        return retValue;
    }

    //------------------------------------------------------------------------------
    // Following method disposes all the class members
    //------------------------------------------------------------------------------
    public void Dispose()
    {
        try
        {
            if (isDisposeCalled == false)
            {
                //TODO: Add your application code here 
            }
            isDisposeCalled = true;
        }
        catch (NXOpen.NXException ex)
        {
            // ---- Enter your exception handling code here -----

        }
    }

    public static int GetUnloadOption(string arg)
    {
        //Unloads the image explicitly, via an unload dialog
        //return System.Convert.ToInt32(Session.LibraryUnloadOption.Explicitly);

        //Unloads the image immediately after execution within NX
        // return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);

        //Unloads the image when the NX session terminates
        return System.Convert.ToInt32(Session.LibraryUnloadOption.AtTermination);
    }

}

