Research GUI For Proffitt Lab
================================================================================

Package contents:

   *"Canvas" element that should be named ResearchGUI

   *ResearchGUIScript to facilitate the functionality of the GUI

Installation and Set-up
------------------------

   1. Using Unity, select Assets -> Import Package -> Custom Package...

   2. Make sure all the components are selected, then import all.

   3. Take the two created prefabs in the prefab folder and put them in the
        Hierarchy.

   4. Make sure that the ResearchGUI menu is open so that you can see inside it

   5. Select the script, and drag and drop components to fill the script up.

      *ResearchGUI -> Menu

      *RA_Name -> Ra Name

      *Participant_Name -> Partic

      *Exp_Name -> Exp

      *Age_input -> Age

      *Height -> Height

      *Weight -> Weight

      *Other -> Other

      *LeftToggle -> Left

      *Right Toggle -> Right

      *GenderInput -> Sex

      *Export -> Export

      Note: Each of these names refers the the name of a part in ResearchGUI

      !Addition: If using Google Height World Ver., also put the GainRig obj
        into the GainRig slot!

   6. The script should be ready to use with default output file name default
        and hide/show key set to "escape"

Changing Element Names
----------------------

   1. Select the field you want to change in the ResearchGUI Object

   2. Click on the Label Object, and change the text field

   3. Open the input, and change the placeholder text

   4. After generating the data file, change the column heading in that as well

FAQ
----------------------

   How do I change the hide/show key?

      *After starting up the test, navigate to the script object and change the
         values in the public areas.

   How do I change the output file name?

      *Follow the same thing as the previous question, but for file name instead

   How does the GainRig system work?

      *It utilizes the text variable inside the GainRig script, so you need to
         make the text variable public inside GainRig, and also provide its
         position to the ResearchGUI script. It should then output to the end
         of each line in the output.

Changelog
----------------------

   3/23

    Created a new version that works with GainRig scripts attached, specifically
      for Google Height World studies.

    New package that works with that, named GoogleHeightWorldGUI

---------------------------------------------------------------------------------
Created by Jonathan Ting
Reach me at: jt4ue@virginia(dot)edu