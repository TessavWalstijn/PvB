// This using at top of a Class
using UnityEngine;

// Naming of brackets:
// • brackets   => ()
// • braces     => {}
// • crotchets  => []
// • brokets    => <>

public class CodeConfentions
// Optional class creations:
//      public class CodeConfentions : MonoBehaviour
//      public class CodeConfentions : _ClassUsedOnlyHere
{   // We set the braces on the next line to know that it is a function or class

    // We always place the variables at top of the class
    
    // Functions and Variable order for class types:
    // • private
    // • protected
    // • public
    // • private static
    // • protected static
    // • public static

    // We want to use privates at moost of the time
    // For variables we use the [SerializeField] like show below:
    [SerializeField]
    private int _test = 0;
    public int test { get { return _test; } }

    private int _Test ( // Private functions start with an _
        int     a, // If we have more then 3 parameters
        float   b, // We will list the parameters like this
        double  c, // We add a TAB to make a differnce between names and types
        int     d, // We do this to make the parameters more readable
    ) {   // We now add the last bracket and the first brace together

        int max = 10;
        for (int i = 0; i < max; i += 1) {
            // We place the brace after a forloop, if, switch, etc.
            // We use the += to make an easy change the the step of a forloop
            // We do not read the length of an array or list in the forloop for readability
            if (
                i % 3 == 0 && // When we use the && we use a different syntax
                i % 5 == 0    // The syntax is the same as a function with more then 3 params
            ) {   // We now add the last bracket and the first brace together\
                _test += 1 // We do not use the ++ operator on number types
            }
        }
    }

    // Start is called before the first frame update
    // We add public to the Unity3D functions if we use MonoBehaviour!
    public void Start()
    {
        // This is oke because it keeps it simple and short
        _Test(1, 2, 3, 4);

        _Test( // This is more readable for long or a lot of params
            1,
            2.22,
            3456789.0123456789,
            4
        );
    }
}
