Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Samples

    Public Class FaAllocationSamples

        '! [faonegroup]
        'Replace with your own accountIds
        Public Shared FaOneGroup As String = "<?xml version=""1.0"" encoding=""UTF-8""?>" &
               "<ListOfGroups>" &
               "<Group>" &
                   "<name> Equal_Quantity</name>" &
                   "<ListOfAccts varName=""list"">" &
                        "<String>DU119915</String>" &
                        "<String>DU119916</String>" &
                   "</ListOfAccts>" &
                   "<defaultMethod>EqualQuantity</defaultMethod>" &
                "</Group>" &
               "</ListOfGroups>"
        '! [faonegroup]

        '! [fatwogroups]
        'Replace with your own accountIds
        Public Shared FaTwoGroups As String = "<?xml version=""1.0"" encoding=""UTF-8""?>" &
        "<ListOfGroups>" &
        "<Group>" &
        "<name> Equal_Quantity</name>" &
                 "<ListOfAccts varName = ""list"">" &
                     "<String> DU119915</String>" &
                     "<String> DU119916</String>" &
                 "</ListOfAccts>" &
                 "<defaultMethod> EqualQuantity</defaultMethod>" &
             "</Group>" &
             "<Group>" &
        "<name> Pct_Change</name>" &
                 "<ListOfAccts varName = ""list"">" &
                     "<String> DU119915</String>" &
                     "<String> DU119916</String>" &
                 "</ListOfAccts>" &
                 "<defaultMethod> PctChange</defaultMethod>" &
             "</Group>" &
         "</ListOfGroups>"
        '! [fatwogroups]

        '! [faoneprofile]
        'Replace with your own accountIds
        Public Shared FaOneProfile As String = "<?xml version=""1.0"" encoding=""UTF-8""?>" &
            "<ListOfAllocationProfiles>" &
            "<AllocationProfile>" &
                "<name> Percent_60_40</name>" &
                "<Type>1</type>" &
                    "<ListOfAllocations varName=""listOfAllocations"">" &
                    "<Allocation>" &
                     "<acct> DU119915</acct>" &
                     "<amount>60.0</amount>" &
                    "</Allocation>" &
                   "<Allocation>" &
                    "<acct> DU119916</acct>" &
                     "<amount>40.0</amount>" &
                   "</Allocation>" &
                    "</ListOfAllocations>" &
           "</AllocationProfile>" &
          "</ListOfAllocationProfiles>"
        '! [faoneprofile]

        '! [fatwoprofiles]
        'Replace with your own accountIds
        Public Shared FaTwoProfiles As String = "<?xml version=""1.0"" encoding=""UTF-8""?>" &
             "<ListOfAllocationProfiles>" &
        "<AllocationProfile>" &
        "<name> Percent_60_40</name>" &
                 "<Type>1</type>" &
                 "<ListOfAllocations varName = ""listOfAllocations"">" &
                     "<Allocation>" &
        "<acct> DU119915</acct>" &
                         "<amount>60.0</amount>" &
                     "</Allocation>" &
                     "<Allocation>" &
        "<acct> DU119916</acct>" &
                         "<amount>40.0</amount>" &
                     "</Allocation>" &
                 "</ListOfAllocations>" &
             "</AllocationProfile>" &
             "<AllocationProfile>" &
        "<name> Ratios_2_1</name>" &
                 "<Type>1</Type>" &
                 "<ListOfAllocations varName = ""listOfAllocations"">" &
                     "<Allocation>" &
                         "<acct> DU119915</acct>" &
                         "<amount>2.0</amount>" &
                     "</Allocation>" &
                     "<Allocation>" &
        "<acct> DU119916</acct>" &
                         "<amount>1.0</amount>" &
                     "</Allocation>" &
                 "</ListOfAllocations>" &
             "</AllocationProfile>" &
         "</ListOfAllocationProfiles>"
        '! [fatwoprofiles]
    End Class
End Namespace

