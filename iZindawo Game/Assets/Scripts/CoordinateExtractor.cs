using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateExtractor : MonoBehaviour
{
    // Dictionary to store sprite positions based on their names
    private Dictionary<string, Vector2> spritePositions = new Dictionary<string, Vector2>();

   void Start()
        {
            // Array of sprite names
            string[] spriteNames = {
            "P(0,0)", "P(0,1)", "P(0,2)", "P(0,3)", "P(0,4)",
            "P(1,0)", "P(1,1)", "P(1,2)", "P(1,3)", "P(1,4)",
            "P(2,0)", "P(2,1)", "P(2,2)", "P(2,3)", "P(2,4)",
            "P(3,0)", "P(3,1)", "P(3,2)", "P(3,3)", "P(3,4)",
            "P(4,1)", "P(4,2)", "P(4,3)", "P(4,4)",
            "Y(0,0)", "Y(0,1)", "Y(0,2)", "Y(0,3)", "Y(0,4)",
            "Y(1,0)", "Y(1,1)", "Y(1,2)", "Y(1,3)", "Y(1,4)",
            "Y(2,0)", "Y(2,1)", "Y(2,2)", "Y(2,3)", "Y(2,4)",
            "Y(3,0)", "Y(3,1)", "Y(3,2)", "Y(3,3)", "Y(3,4)",
            "Y(4,1)", "Y(4,2)", "Y(4,3)", "Y(4,4)",
            "B(0,0)", "B(0,1)", "B(0,2)", "B(0,3)", "B(0,4)",
            "B(1,0)", "B(1,1)", "B(1,2)", "B(1,3)", "B(1,4)",
            "B(2,0)", "B(2,1)", "B(2,2)", "B(2,3)", "B(2,4)",
            "B(3,0)", "B(3,1)", "B(3,2)", "B(3,3)", "B(3,4)",
            "B(4,1)", "B(4,2)", "B(4,3)", "B(4,4)",
            "I(1)", "I(2)", "I(3)",
            "W(1)", "W(2)", "W(3)"
        };

            // Loop through each sprite name
            foreach (string spriteName in spriteNames)
            {
                // Extract the coordinates
                Vector2 coordinates = ExtractCoordinates(spriteName);

                // Store the coordinates in the dictionary
                spritePositions.Add(spriteName, coordinates);
            }

            // Example usage: Retrieve the starting position of a sprite
            Vector2 startingPosition = spritePositions["P(2,2)"];
            Debug.Log("Starting position of sprite P(2,2): " + startingPosition);
        }

        // Function to extract the coordinates from a sprite name
        private Vector2 ExtractCoordinates(string spriteName)
        {
            // Extract the coordinate substring
            string coordinateSubstring = spriteName.Substring(spriteName.IndexOf('(') + 1);
            // Remove the closing parenthesis
            coordinateSubstring = coordinateSubstring.Remove(coordinateSubstring.Length - 1);

            // Split the coordinate substring into x and y components
            string[] coordinateComponents = coordinateSubstring.Split(',');

            // Extract the x and y coordinates as strings
            string xCoordinate = coordinateComponents[0];
            string yCoordinate = coordinateComponents[1];

            // Convert the x and y coordinate strings to integers
            int xCoord = int.Parse(xCoordinate);
            int yCoord = int.Parse(yCoordinate);

            // Return the x and y coordinates as a Vector2
            return new Vector2(xCoord, yCoord);
        }
    }

