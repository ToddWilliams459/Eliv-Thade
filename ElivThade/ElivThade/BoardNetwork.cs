using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElivThade
{
     public class BoardNetwork
    {
         //60,55   actually 57

         public Node Start;
         public Node tempVar;
         public Node Room1;
         public Node Room2;
         public Node Room3;
         public Node Room4;
         public Node tail;

         public BoardNetwork()
        {
            Start =  new Node(375,520);
            addUp(Start);
            tempVar = Start.Up;

            // right hall passage
            addRight(tempVar);
            addRight(tempVar.Right);
            addUp(tempVar.Right.Right);
            addRight(tempVar.Right.Right.Up);
            addRightR(tempVar.Right.Right.Up.Right, 615, 406, 100, 100);     //Room End
            tail = tempVar.Right.Right.Up.Right.Right;

            //left pessage
            addLeft(tempVar);
            addLeft(tempVar.Left);
            addLeft(tempVar.Left.Left);
            //5 negative x 2 negative ys
            addLeftL(tempVar.Left.Left.Left, 75, 406, 60, 57);   //Room1
            Room1 = tempVar.Left.Left.Left.Left;
            tempVar = Room1;

            //after room1     in this section temp var = room 1
            addUp(tempVar);
            addUp(tempVar.Up);
            tempVar = tempVar.Up.Up;  // temp var now equals the 2 up squares from room 1 
            Node tempVar2 = tempVar;   // create this node so now i can use it to go up hall and original node to go right

            //Right path after room1
            addRight(tempVar);
            addRight(tempVar.Right);
            addRight(tempVar.Right.Right);
            addRightR(tempVar.Right.Right.Right, 375, 292, 60, 57);
             Room2 = tempVar.Right.Right.Right.Right;
            tempVar = Room2;

            //Up path   now that i created the right path below i use previously saved tempvar2 to go up   
            addUp(tempVar2);
            addUp(tempVar2.Up);
            addUpP(tempVar2.Up.Up, 135, 7, 50, 50); //UP ROOM 3
             Room3 = tempVar2.Up.Up.Up;    //Room3


            //After Room 2 which is room to the right
            addRight(tempVar);
            addRight(tempVar.Right);
            addUp(tempVar.Right.Right);
            addUp(tempVar.Right.Right.Up);
            addRight(tempVar.Right.Right.Up.Up);
            addRight(tempVar.Right.Right.Up.Up.Right);
            addUp(tempVar.Right.Right.Up.Up.Right.Right);
            addUpP(tempVar.Right.Right.Up.Up.Right.Right.Up, 555, 7, 50, 50);   //3 right 8 up
            Room4 = tempVar.Right.Right.Up.Up.Right.Right.Up.Up;   //Room4
            tempVar = Room4;

            //Make Room 4 go to Room 3  the top right room going to top left
            addLeft(tempVar);
            addLeft(tempVar.Left);
            addDown(tempVar.Left.Left);
            addLeft(tempVar.Left.Left.Down);
            addLeft(tempVar.Left.Left.Down.Left);
            //re setting temp var so it isnt so hard to keep up
            tempVar = tempVar.Left.Left.Down.Left.Left;
            addUp(tempVar);
            addLeft(tempVar.Up);
            addLeft(tempVar.Up.Left);
            tempVar.Up.Left.Left.Left = Room3;
            Room3.Right = tempVar.Up.Left.Left;

           
           
       
        }


        public void addLeft(Node thisNode)
        {
            thisNode.Left = new Node(thisNode.LocX - thisNode.Width, thisNode.LocY);
            (thisNode.Left).Right = thisNode;
        }

        public void addRight(Node thisNode)
        {
            thisNode.Right = new Node(thisNode.LocX + thisNode.Width, thisNode.LocY);
            (thisNode.Right).Left = thisNode;
        }

        public void addUp(Node thisNode)
        {
            thisNode.Up = new Node(thisNode.LocX, thisNode.LocY - thisNode.Height);
            (thisNode.Up).Down = thisNode;
        }

        public void addDown(Node thisNode)
        {
            thisNode.Down = new Node(thisNode.LocX, thisNode.LocY + thisNode.Height);
            (thisNode.Down).Up = thisNode;
        }


        public void addRightR(Node thisNode,int X,int Y,int Height,int Width)
        {
            thisNode.Right = new Node(X,Y,Height,Width);
            (thisNode.Right).Left = thisNode;
        }

        public void addLeftL(Node thisNode, int X, int Y, int Height, int Width)
        {
            thisNode.Left = new Node(X, Y, Height, Width);
            (thisNode.Left).Right = thisNode;
        }

        public void addUpP(Node thisNode, int X, int Y, int Height, int Width)
        {
            thisNode.Up = new Node(X, Y, Height, Width);
            (thisNode.Up).Down = thisNode;
        }


        // Add Node Method
        //Take Current Node  
        //Create Node In Direction Desired
    }
}
