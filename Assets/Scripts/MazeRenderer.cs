using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    [Range(1,50)]
    private int cols;

    [SerializeField]
    [Range(1,50)]
    private int rows;

    [SerializeField]
    private Transform wallPrefab = null;
    [SerializeField]
    private Transform groundPrefab = null;

    [SerializeField]
    private float cellSize = 1f;

    private List<Transform> walls;

    void Start()
    {
        walls = new();
        var groundPosition  = Vector3.zero - new Vector3(cellSize/2,
                                                        wallPrefab.transform.position.y 
                                                        + wallPrefab.localScale.y/2,
                                                        cellSize/2);
        Instantiate(groundPrefab, groundPosition, Quaternion.identity, transform);

        WallStatus[,] maze = MazeGenerator.Generate(cols, rows);
        Draw(maze);
    }

    public void ResetMaze()
    {
        foreach(Transform wall in walls)
        {
            if(wall != null)
                Destroy(wall);
        }
        WallStatus[,] maze = MazeGenerator.Generate(cols, rows);
        Draw(maze);
    }

    private void CreateWall(Vector3 position, Vector3 offset, Vector3 rotation)
    {
        Transform wall = Instantiate(wallPrefab, transform);
        wall.position = position + offset;
        
        var localScale = wall.localScale;
        localScale = new Vector3(cellSize, localScale.y, localScale.z);
        wall.localScale = localScale;
        
        wall.eulerAngles = rotation;
        
        walls.Add(wall);
    }

    private void Draw(WallStatus[,] maze) 
    {
        for(int i=0; i<rows; i++)
        {
            for(int j=0; j<cols; j++)
            {
                var cell = maze[i,j];
                var position = new Vector3(-cols/2+i, 0, -rows/2+j);
                if(cell.HasFlag(WallStatus.UP))
                {
                    var offset = new Vector3(0,0, cellSize/2);
                    CreateWall(position, offset, Vector3.zero);
                }
                if(cell.HasFlag(WallStatus.LEFT))
                {
                    var offset = new Vector3(-cellSize/2,0,0);
                    CreateWall(position, offset, Vector3.up * 90);
                }
                if(i == cols-1)
                {
                    if(cell.HasFlag(WallStatus.RIGHT))
                    {
                        var offset = new Vector3(cellSize/2,0,0);
                        CreateWall(position, offset, Vector3.up * 90);
                    }

                    if (j == rows - 1)
                    {
                        GameEnv.Instance.endPoint = Instantiate(ResourceLoader.endPoint, GameEnv.Instance.maze.transform);
                        GameEnv.Instance.endPoint.transform.position = position + new Vector3(0f, -0.1f, 0f);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallStatus.DOWN))
                    {
                        var offset = new Vector3(0, 0, -cellSize / 2);
                        CreateWall(position, offset, Vector3.zero);
                    }

                    if (i == 0)
                    {
                        GameEnv.Instance.spawnPoint = Instantiate(ResourceLoader.spawnPoint, GameEnv.Instance.maze.transform);
                        GameEnv.Instance.spawnPoint.transform.position = position + new Vector3(0f, -0.1f, 0f);
                    }
                }
            }
        }
    }
}
