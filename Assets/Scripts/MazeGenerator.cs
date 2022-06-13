using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum WallStatus{
    LEFT = 1, //0001
    RIGHT = 2, //0010
    UP = 4, //0100
    DOWN = 8, //1000

    VISITED = 128, //1000 0000
}

public struct Position
{
    public int x;
    public int y;
}

public struct NeighborCell
{
    public Position position;
    public WallStatus sharedWall;
}

public static class MazeGenerator
{
    private static WallStatus GetOppWall(WallStatus wall) //Get opposite wall
    {
        switch(wall)
        {
            case WallStatus.RIGHT: return WallStatus.LEFT;
            case WallStatus.LEFT: return WallStatus.RIGHT;
            case WallStatus.UP: return WallStatus.DOWN;
            case WallStatus.DOWN: return WallStatus.UP;
            default: return WallStatus.VISITED; //dummy case
        }
    }

    private static WallStatus[,] Backtrack(WallStatus[,] maze, int width, int height) // Recursive backtracker algorithm
    {
        DateTime centuryBegin = new DateTime(2001, 1, 1);
        DateTime currentDate = DateTime.Now;
        long elapsedSecs = currentDate.Second - centuryBegin.Second;

        var rnGenerator = new System.Random((int)elapsedSecs); //Random mumber generator
        var posStack = new Stack<Position>();
        var position = new Position{x = rnGenerator.Next(0, width), y = rnGenerator.Next(0, height)};

        maze[position.x, position.y] |= WallStatus.VISITED; //OR operation
        posStack.Push(position);

        while(posStack.Count > 0)
        {
            var currPos = posStack.Pop();
            var validNeighborCells = GetUnvisitedNeighborCells(currPos, maze, width, height);

            if(validNeighborCells.Count > 0)
            {
                posStack.Push(currPos);
                var rand = rnGenerator.Next(0, validNeighborCells.Count);
                var randNeighborCell = validNeighborCells[rand];

                var nPos = randNeighborCell.position;
                maze[currPos.x, currPos.y] &= ~randNeighborCell.sharedWall;
                maze[nPos.x, nPos.y] &= ~GetOppWall(randNeighborCell.sharedWall);
                maze[nPos.x, nPos.y] |= WallStatus.VISITED;

                posStack.Push(nPos);
            }
        }
        return maze;
    }

    private static void AddToNeighborCellList(Position pos, int offsetx, int offsetY, 
                                          List<NeighborCell> list, WallStatus[,] maze,
                                          WallStatus statusCode)
    {
        if(!maze[pos.x + offsetx, pos.y + offsetY].HasFlag(WallStatus.VISITED))
        {
            list.Add(new NeighborCell{
                        position = new Position
                        {
                            x = pos.x+offsetx,
                            y = pos.y+offsetY
                        },
                        sharedWall = statusCode
                    }); 
        }
    }
    private static List<NeighborCell> GetUnvisitedNeighborCells(Position pos, WallStatus[,] maze, int width, int height)
    {
        var list = new List<NeighborCell>();

        //Left
        if(pos.x > 0) AddToNeighborCellList(pos,-1,0,list, maze, WallStatus.LEFT);
        //Up
        if(pos.y < height-1) AddToNeighborCellList(pos,0,1,list, maze, WallStatus.UP);
        //Right
        if(pos.x < width-1) AddToNeighborCellList(pos,1,0,list, maze, WallStatus.RIGHT);
        //Down
        if(pos.y > 0) AddToNeighborCellList(pos,0,-1,list, maze, WallStatus.DOWN);
        
        return list;
    }

    public static WallStatus[,] Generate(int width, int height)
    {
        WallStatus[,] maze = new WallStatus[width, height];
        WallStatus initState = WallStatus.LEFT|WallStatus.RIGHT|WallStatus.UP|WallStatus.DOWN;
        for(int i=0; i<height; i++)
        {
            for(int j=0; j<width; j++)
            {
                maze[i, j] = initState;
            }
        }
        return Backtrack(maze, width, height);
    }
}
