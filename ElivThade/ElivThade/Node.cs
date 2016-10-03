using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElivThade
{
    public class Node
    {
        //on creation of new node, figure out location based on position to preexisting node
         
        // Attributes
       
        
        /// Gets and sets the data of this node

        public int LocX{get; set; }
          
        

        public int LocY {get; set;}
      
      

        /// <summary>
        /// Gets and sets the next node
        /// </summary>
        public Node Left{get; set;}
      
        /// <summary>
        /// Gets and sets the previous node
        /// </summary>
        public Node Right{get; set;}
       

        public Node Up{get; set;}
     

        public Node Down{get; set;}
       

        public int Height{get; set;}
      

        public int Width{get; set;}
     

        /// <summary>
        /// Creates a new Node with data
        /// </summary>
        /// <param name="data">The data to hold in this node</param>
        
        public Node(int LocXin, int LocYin)
        {
            this.LocX = LocXin;
            this.LocY = LocYin;
            this.Left = null;
            this.Right = null;
            this.Up = null;
            this.Down = null;
            this.Height= 57;
            this.Width = 60;
        }

        public Node(int LocX, int LocY,int Height, int Width)
        {
            this.LocX = LocX;
            this.LocY = LocY;
            this.Left = null;
            this.Right = null;
            this.Up = null;
            this.Down = null;
            this.Height = Height;
            this.Width = Width;
        }


        
    }
}
