using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TJS.GravCalculator.BL
{
    public class ForceHelpers
    {
        
        //        F = G* M * m / R^2

        //F stands for gravitational force.It is measured in Newtons and is always positive. 
        //It means that two objects of a certain mass always attract (and never repel) each other;
        // M and m are the masses of two objects in question;
        //R is the distance between the centers of these two objects, and
        //G is the gravitational constant.It is equal to 6.674 * 10^(-11) N* m^2/kg^2

        public static readonly double GravitaionalConstant = 6.674 * Math.Pow(10, -11);
        
        public static double GetForceDueToGravity(double mass1, double mass2, double distance)
        {
            return GravitaionalConstant * mass1 * mass2 / (distance * distance);
        }
                

        public ForceHelpers()
        {

        }
       
    } 

}
