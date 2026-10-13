namespace c__oop_ass5;

internal class Program
{
    static void Main(string[] args)
    {



        /*
                 # Part 01 — Theoretical Questions

         
            Q1)

              a- Assign one class object variable to another copies the reference, 
                 so both variables refer to the same object.

              b- No, assignment does not create a new object; 
                 it only copies the reference to the existing object.

              c- c) Copying an object creates a separate instance, 
                   while copying its reference makes both variable refer to the same instance.




             Q2) 

               a- A shallow copy creates a new object but shares referenced objects with the original.
                      
               b- A deep copy creates a new object and independent copies of its referenced objects.

               c- their references are copied, so both objects share the same referenced objects.

               d- he make 2 reference separate copies of the original’s referenced objects.
          
               e- Deep copy is safer when copying an object contain a mutable list
                  that must be edited without affecting in the original.



              Q3)

               a- static field belong to the class and is shared by all instances, 
                   while an instance field belong to each individual object.

               b-  static method belong to the class and can be called without an object .

               c- static constructor initializes the class’s static data and 
                  run automatically once, before the first instance is created.

               d- static class contains only static members and cannot be instantiated.

               
               Q4)

               a- extension method adds functionality to an existing type
                   without modifying its original code.

               b- [this] keyword must be used before the first parameter to specify the type being extended.

               c- An extension method must be a static method inside a static class.

               d- No, an extension method cannot access private members of the type it extends.

              Q5)

               a- A partial class is a class whose code is split into across multiple files.

               b- Developers split a class into multiple files to organize code 
                  and separate generated code from handwritten code.

               c- : A partial method can be declared in one part of a partial class 
                    and implemented in another part.

               d- If a partial method has no implementation, the compiler removes its declaration and calls.
                   and no compilation error happen .
            

        */





        DeliveryUtilities.PrintSystemTitle();

        // استدعاء الدالة باسم الكلاس بدون إنشاء شحنة
        // هنا الـ static constructor يشتغل تلقائيًا لأول مرة
        Console.WriteLine
        (
            "Total Shipments Created : " + Shipment.GetTotalShipmentsCreated()
        );


        DeliveryCenter center = new DeliveryCenter();  // object 

        Console.Write("Enter Center Name: ");
        center.CenterName = Console.ReadLine();


        Console.WriteLine("\nEnter Standard Shipment Data:");
        //------------------------------------------------
        Console.Write("Tracking Code: ");
        string trackingCode = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Weight: ");
        decimal weight = decimal.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal deliveryFee = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string city = Console.ReadLine();

        Console.Write("Street: ");
        string street = Console.ReadLine();

        Console.Write("Building Number: ");
        int buildingNumber = int.Parse(Console.ReadLine());
        // ----------------------------------------------------

        DeliveryAddress destination =
            new DeliveryAddress(city, street, buildingNumber);

        StandardShipment standard = new StandardShipment(
            trackingCode,
            description,
            weight,
            deliveryFee,
            destination
        );


        Console.WriteLine("\nEnter Express Shipment Data:");
        //-------------------------------------------------------
        Console.Write("Tracking Code: ");
        string expressTrackingCode = Console.ReadLine();

        Console.Write("Description: ");
        string expressDescription = Console.ReadLine();

        Console.Write("Weight: ");
        decimal expressWeight = decimal.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal expressDeliveryFee = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string expressCity = Console.ReadLine();

        Console.Write("Street: ");
        string expressStreet = Console.ReadLine();

        Console.Write("Building Number: ");
        int expressBuildingNumber = int.Parse(Console.ReadLine());

        Console.Write("Extra Fee: ");
        decimal extraFee = decimal.Parse(Console.ReadLine());
        //------------------------------------------------------------

        DeliveryAddress expressDestination =
            new DeliveryAddress(
                expressCity,
                expressStreet,
                expressBuildingNumber
            );

        ExpressShipment express = new ExpressShipment(
            expressTrackingCode,
            expressDescription,
            expressWeight,
            expressDeliveryFee,
            expressDestination,
            extraFee
        );




        Console.WriteLine("\nEnter International Shipment Data:");

        //--------------------------------------------------------
        Console.Write("Tracking Code: ");
        string internationalTrackingCode = Console.ReadLine();

        Console.Write("Description: ");
        string internationalDescription = Console.ReadLine();

        Console.Write("Weight: ");
        decimal internationalWeight = decimal.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal internationalDeliveryFee = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string internationalCity = Console.ReadLine();

        Console.Write("Street: ");
        string internationalStreet = Console.ReadLine();

        Console.Write("Building Number: ");
        int internationalBuildingNumber = int.Parse(Console.ReadLine());

        Console.Write("Destination Country: ");
        string destinationCountry = Console.ReadLine();

        Console.Write("Customs Fee: ");
        decimal customsFee = decimal.Parse(Console.ReadLine());
        //--------------------------------------------------------------------------

        DeliveryAddress internationalDestination =
            new DeliveryAddress(
                internationalCity,
                internationalStreet,
                internationalBuildingNumber
            );

        InternationalShipment international = new InternationalShipment(
                internationalTrackingCode,
                internationalDescription,
                internationalWeight,
                internationalDeliveryFee,
                internationalDestination,
                destinationCountry,
                customsFee
            );

        DeliveryUtilities.PrintSeparator();

        Console.WriteLine
        (
            "Total Shipments Created : " + Shipment.GetTotalShipmentsCreated()
        );

        //----------------------------------------------------------------------------
        //----------------------------------------------------------------------------

        // Add Shipments
        center.AddShipment(standard);
        center.AddShipment(express);
        center.AddShipment(international);


        // i. Print Shipment Details
        DeliveryHelper.PrintShipmentDetails(standard);
        DeliveryHelper.PrintShipmentDetails(express);
        DeliveryHelper.PrintShipmentDetails(international);


        // j. Demonstrate Method Overloading
        standard.UpdateWeight(10);
        express.UpdateWeight(10, 2);


        // k. Demonstrate Polymorphism Using a Shipment Array
        Shipment[] shipments = { standard, express, international };

        Console.WriteLine("\nMixed Shipments:");

        foreach (Shipment shipment in shipments)
        {
            shipment.PrintShipment();
        }


        // l. Create Completed and Priority International Shipments
        CompletedShipment completed = new CompletedShipment(
            "C001",
            "Completed Shipment",
            10,
            100,
            destination
        );

        PriorityInternationalShipment priority = new PriorityInternationalShipment(
            "P001",
            "Priority Shipment",
            10,
            100,
            destination,
            "Egypt",
            50
        );

        priority.GenerateCustomsReport();


        // Print All Shipments in the Delivery Center
        Console.WriteLine("\nAll Shipments:");
        center.PrintAllShipments();


        // Search for a Shipment by Tracking Code
        Console.Write("\nEnter Tracking Code to search: ");
        string searchCode = Console.ReadLine();

        Shipment found = center[searchCode];

        if (found != null)
        {
            found.PrintShipment();
        }
        else
        {
            Console.WriteLine("Shipment not found.");
        }


        // Remove a Shipment by Tracking Code
        Console.Write("\nEnter Tracking Code to remove: ");
        string removeCode = Console.ReadLine();

        bool removed = center.RemoveShipment(removeCode);

        if (removed)
        {
            Console.WriteLine("Shipment removed successfully.");
        }
        else
        {
            Console.WriteLine("Shipment not found.");
        }


        // Print Remaining Shipments
        Console.WriteLine("\nRemaining Shipments:");
        center.PrintAllShipments();


        // Print Tracking Status Using DeliveryReport
        DeliveryReport report = new DeliveryReport();

        Console.WriteLine("\nTracking Status:");

        report.PrintShipment(standard);
        report.PrintShipment(express);
        report.PrintShipment(international);


        // Print Insurance Using DeliveryReport
        Console.WriteLine("\nInsurance:");

        report.PrintInsurance(standard);
        report.PrintInsurance(express);
        report.PrintInsurance(international);


        // Demonstrate Different Shipment Types Using an ITrackable Array
        Console.WriteLine("\nTracking Status Using ITrackable Array:");

        ITrackable[] trackableShipments =
        {
            standard,
            express,
            international
        };

        foreach (ITrackable shipment in trackableShipments)
        {
            Console.WriteLine(shipment.GetTrackingStatus());
        }


        // Demonstrate Different Shipment Types Using an IInsurable Array
        Console.WriteLine("\nInsurance Using IInsurable Array:");

        IInsurable[] insurableShipments =
        {
            standard,
            express,
            international
        };

        foreach (IInsurable shipment in insurableShipments)
        {
            Console.WriteLine(shipment.CalculateInsurance());
        }


        //---------------------------------------------------------------------------------------



        // Reference Assignment

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Reference Assignment:");

        Shipment shipment1 = standard;
        Shipment shipment2 = shipment1;

        Console.WriteLine
        (
            // بتسأل: هل المتغيرين بيشاوروا على نفس الأوبجكت؟ <-- (ReferenceEquals)
            // نفس الشحنة، لم يتم إنشاء شحنة جديدة
            "Same object? " + object.ReferenceEquals(shipment1, shipment2)
        ); 

        //  Shallow Copy

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Shallow Copy:");

        shipment1.Destination.City = "Cairo";

        Shipment shallow = shipment1.ShallowCopy();

        Console.WriteLine
        (
            "Same shipment? " + object.ReferenceEquals(shipment1, shallow)
        ); // False

        Console.WriteLine
        (
            "Same address? " +
            object.ReferenceEquals(shipment1.Destination, shallow.Destination)
        ); // True

        Console.WriteLine("Original before: " + shipment1.Destination.City);
        Console.WriteLine("Copied before: " + shallow.Destination.City);

        shallow.Destination.City = "Giza";

        Console.WriteLine("Original after: " + shipment1.Destination.City); // Giza
        Console.WriteLine("Copied after: " + shallow.Destination.City);    // Giza
        // مش لأن الشحنتين نفس الأوبجكت، لكن لأن عنوانهم نفس الأوبجكت.


        // Deep Copy

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Deep Copy:");

        shipment1.Destination.City = "Cairo";

        Shipment deep = shipment1.DeepCopy();

        Console.WriteLine
        (
            "Same shipment? " + object.ReferenceEquals(shipment1, deep)
        ); // False

        Console.WriteLine
        (
            "Same address? " +
            object.ReferenceEquals(shipment1.Destination, deep.Destination)
        ); // False

        Console.WriteLine("Original before: " + shipment1.Destination.City);
        Console.WriteLine("Copied before: " + deep.Destination.City);

        deep.Destination.City = "Giza";

        Console.WriteLine("Original after: " + shipment1.Destination.City); // Cairo
        Console.WriteLine("Copied after: " + deep.Destination.City);       // Giza


        // Extension Methods

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Extension Methods:");

        Console.WriteLine(standard.GetSummary());
        Console.WriteLine(express.GetSummary());
        Console.WriteLine(international.GetSummary());

        Console.WriteLine("Standard delivered? " + standard.IsDelivered());
        Console.WriteLine("International delivered? " + international.IsDelivered());


        // Partial Method
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Partial Method:");

        // تطبع: Tracking status changed to: Out For Delivery
        standard.UpdateTrackingStatus("Out For Delivery");
        

        Console.WriteLine(standard.GetTrackingStatus());


        // Static Counter
        DeliveryUtilities.PrintSeparator();

        Console.WriteLine
        (
            "Total Shipments Created : " + Shipment.GetTotalShipmentsCreated()
        );





















    }
}
