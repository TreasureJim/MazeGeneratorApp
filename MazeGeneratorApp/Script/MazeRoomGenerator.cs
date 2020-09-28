using System;
using System.Collections.Generic;
using System.Linq;

public class MazeRoomGenerator
{
	//Map Generation Settings
	// Map size must be an odd size
	public int mapSize = 10;
	public int minRoomSize;
	public int maxRoomSize;
	public int roomBuildAttempts;
	//Connection chance must be between 0 and 100%
	public int connectionChance;
	//Winding chance must be between 0 and 100%
	public int windingChance;
	public bool removeDeadEnds;


	Random rnd;


	// PRIVATE VARIABLES
	public TileType[,] levelTiles;
	// door connectors: region, door pos
	Dictionary<int, List<int[]>> doorConnectors = new Dictionary<int, List<int[]>>();
	int[,] levelRegions;
	public int currentRegion = -1;
	public enum TileType { Floor, Wall, Room, Door }
	List<Room> roomList = new List<Room>();

	// CONSTANTS
	//		Directions
	readonly static int[] north = { 0, 1 };
	readonly static int[] south = { 0, -1 };
	readonly static int[] east = { 1, 0 };
	readonly static int[] west = { -1, 0 };
	readonly static int[][] cardinalDirections = { north, south, east, west };
	readonly static int[] northEast = { 1, 1 };
	readonly static int[] northWest = { -1, 1 };
	readonly static int[] southEast = { 1, -1 };
	readonly static int[] southWest = { -1, -1 };
	readonly static int[][] northCells = { north, northEast, northWest };
	readonly static int[][] southCells = { south, southEast, southWest };
	readonly static int[][] eastCells = { east, northEast, southEast };
	readonly static int[][] westCells = { west, northWest, southWest };


	// Level Setup
	public int GenerateLevel()
	{
		rnd = new Random();



		// Reset level before writing anything new
		ClearLevel();
		// Setup all variables
		SetupLevel();
		// Add rooms to the level
		AddRooms();
		// Grow the maze in the empty regions of the level
		GenerateMaze();
		// Add connectors between each region
		ConnectRegions();
		// Remove dead ends from level if enabled
		if (removeDeadEnds) { RemoveDeadEnds(); }

		return 1;
	}

	public void SetupLevel()
	{
		currentRegion = -1;

		if (mapSize % 2 == 0) { 
			mapSize--; 
		}
		if (mapSize < 5)
        {
			mapSize = 5;
        }


		// Level will hold information for all walls of the level
		levelTiles = new TileType[mapSize, mapSize];
		// Filling the level with 0s
		for (int y = 0; y < mapSize; y++)
		{
			for (int x = 0; x < mapSize; x++)
			{
				levelTiles[x, y] = TileType.Wall;
			}
		}

		// Regions handles what region each cell is part of
		// -1 represents no region
		levelRegions = new int[mapSize, mapSize];
		for (int y = 0; y < mapSize; y++)
		{
			for (int x = 0; x < mapSize; x++)
			{
				levelRegions[x, y] = -1;
			}
		}
	}


	// Level Generation
	public void AddRooms()
	{
		List<Room> rooms = new List<Room>();

		for (int i = 0; i < roomBuildAttempts; i++)
		{
			// Pick a randomly sized room and place it in the world. If it doesn't intersect with any other rooms then keep it
			int roomWidth = rnd.Next((int)Math.Floor((float)minRoomSize / 2), (int)Math.Floor((float)maxRoomSize / 2)) * 2 + 1;
			int roomHeight = rnd.Next((int)Math.Floor((float)minRoomSize / 2), (int)Math.Floor((float)maxRoomSize / 2)) * 2 + 1;
			int x = (rnd.Next(0, mapSize - roomWidth - 1) / 2) * 2 + 1;
			int y = (rnd.Next(0, mapSize - roomHeight - 1) / 2) * 2 + 1;

			Room room = new Room(x, y, roomWidth, roomHeight);

			// If room intersects any other room discard and try again
			bool failed = false;
			foreach (Room otherRoom in rooms)
			{
				if (room.Intersect(otherRoom))
				{
					failed = true;
					break;
				}
			}
			if (!failed)
			{
				rooms.Add(room);

				StartRegion();
				CreateRoom(room);
			}
		}
	}
	public void GenerateMaze()
	{
		// Loop through all cells in the level and grow the maze in all parts that aren't assigned yet
		for (int y = 0; y < mapSize; y++)
		{
			for (int x = 0; x < mapSize; x++)
			{
				if (levelTiles[x, y] == TileType.Wall)
				{
					GrowMaze(x, y);
				}
			}
		}
	}
	public void GrowMaze(int startX, int startY)
	{
		/*
		 * RULES: 
		 *	If any of the neighbour cells to start point (CanCarve == false) are floor then stop.
		 *	Take a random available direction and start carving.
		 *	For each cell that is carved first check if the cell in front of it (travelling in the same direction)
		 *	and the cells to the left and right of the cell is carvable. 
		 *	If isn't then remove that direction from available directions and pick new direction from original cell.
		 *	Repeat until no available directions left
		 */


		int[][] directions = { north, south, east, west };
		int[][] neighbourCells = { north, south, east, west, northEast, northWest, southEast, southWest };

		int[] start = { startX, startY };
		List<int[]> cells = new List<int[]>();
		int[] lastDirection = null;

		// Check if starting point is valid
		foreach (int[] direction in neighbourCells)
		{
			int[] checkCell = { start[0] + direction[0], start[1] + direction[1] };
			if (!CanCarve(checkCell))
			{
				// Throw out start cell and don't start maze from there
				return;
			}
		}

		// Start a new region for the new maze region
		StartRegion();
		Carve(start[0], start[1]);
		cells.Add(start);


		// While there are available cells to travel to run script
		while (cells.Count > 0 && cells.Count < 10000)
		{
			int[] cell = cells[cells.Count - 1];

			List<int[]> unmadeCells = new List<int[]>();

			foreach (int[] direction in directions)
			{
				int[] checkCell = { cell[0] + direction[0], cell[1] + direction[1] };
				if (CanCarve(checkCell, direction))
				{
					unmadeCells.Add(direction);
				}
			}

			// If there are available cells to travel to run script
			if (unmadeCells.Count > 0)
			{
				// Prefer to continue in the last direction travelling if available
				// Random chance for it to choose a different direction
				int[] direction;
				if (unmadeCells.Contains(lastDirection)
					&& (rnd.Next(100) > windingChance))
				{
					direction = lastDirection;
				}
				else
				{
					direction = unmadeCells[rnd.Next(0, unmadeCells.Count)];
				}

				int[] newCell;
				newCell = new int[] { cell[0] + direction[0], cell[1] + direction[1] };
				Carve(newCell[0], newCell[1]);
				// Adds new cell onto stack and script will repeat with this cell until it has no possible directions to travel
				cells.Add(newCell);

				lastDirection = direction;
			}
			else
			{
				cells.RemoveAt(cells.Count - 1);
				lastDirection = null;
			}
		}
	}
	public void ConnectRegions()
	{
		// connectorRegions is an array that holds all the adjecent regions to the location (int[,][])
		int[,][] connectorRegions = new int[mapSize, mapSize][];

		// Loop through entire level
		for (int x = 1; x < mapSize - 1; x++)
		{
			for (int y = 1; y < mapSize - 1; y++)
			{
				// Skip tile if not a wall
				if (levelTiles[x, y] != TileType.Wall) { continue; }

				// count the number of different regions the wall tile is touching
				// Add any adjecent regions to the regions array
				HashSet<int> regions = new HashSet<int>();
				foreach (int[] direction in cardinalDirections)
				{
					int newX = x + direction[0];
					int newY = y + direction[1];
					int? region = levelRegions[newX, newY];
					// If there is no region at that location discard
					if (region > -1) { regions.Add((int)region); }
				}


				// If there is only one or less adjecent regions cast away as it is not a valid connector
				if (regions.Count < 2) { continue; }

				// The wall tile touches at least two regions so add to the connectorRegions array
				connectorRegions[x, y] = regions.ToArray();
			}
		}

		//Make a list of all of the connectors
		// connectors is an array that holds the location for every possible connector
		HashSet<int[]> connectors = new HashSet<int[]>();
		for (int x = 0; x < mapSize; x++)
		{
			for (int y = 0; y < mapSize; y++)
			{
				// If connectorRegions at x,y holds any amount of elements add that location to the connectors array
				try
				{
					if (connectorRegions[x, y].Length > 1)
					{
						int[] connectorPos = { x, y };
						connectors.Add(connectorPos);
					}
				}
				catch (NullReferenceException) { continue; }
			}
		}

		// keep track of the regions that have been merged.
		Dictionary<int, int> merged = new Dictionary<int, int>();
		// openRegions is a list of regions that have yet to be connected 
		HashSet<int> openRegions = new HashSet<int>();
		for (int i = 0; i <= currentRegion; i++)
		{
			// Assigns every region in merged to itself
			merged.Add(i, i);
			// Adds every region to the openRegions set
			openRegions.Add(i);
		}

		// Connect the regions
		while (openRegions.Count > 1)
		{
			//get random connector
			int[][] connectorsArray = connectors.ToArray();
			int[] connector = connectorsArray[rnd.Next(0, connectors.Count)];

			// Carve out connector
			int x = connector[0];
			int y = connector[1];
			Carve(x, y, TileType.Door);

			// Merge the connected regions
			//Make a list of the regions at x, y
			List<int> regions = new List<int>();
			foreach (int n in connectorRegions[x, y])
			{
				// Get the region that it has been merged from and add to regions array
				int actualRegion = merged[n];
				regions.Add(actualRegion);
			}

			int destination = regions[0];
			int[] sources = regions.Skip(1).ToArray();

			/*
			Merge all of the effective regions. You must look
			at all of the regions, as some regions may have
			previously been merged with the ones we are
			connecting now.
			*/
			for (int i = 0; i < currentRegion; i++)
			{
				if (sources.Contains(merged[i]))
				{
					merged[i] = destination;
				}
			}

			// Clear the sources as they are no longer needed
			openRegions.ExceptWith(new HashSet<int>(sources));

			HashSet<int[]> toRemove = new HashSet<int[]>();
			foreach (int[] pos in connectors)
			{
				int xConnector = pos[0];
				int yConnector = pos[1];

				// Remove connectors that are next to the current connector
				if (Distance(connector, pos) < 2)
				{
					toRemove.Add(pos);
					continue;
				}

				HashSet<int> regionsConnector = new HashSet<int>();
				// for every region next to the connector, check if they are still different regions (ie. haven't already been merged) 
				foreach (int n in connectorRegions[x, y])
				{
					int actualRegion = merged[n];
					regions.Add(actualRegion);
				}
				// If connector still connects to an unconnected place then keep
				if (regions.Count > 1) { continue; }

				// Random chance to add a connector
				if (rnd.Next(100) < connectionChance)
				{
					Carve(x, y, TileType.Door);
				}

				// Remove if only joins one real region
				if (regions.Count <= 1)
				{
					toRemove.Add(pos);
				}
			}

			connectors.ExceptWith(toRemove);
		}
	}
	public void RemoveDeadEnds()
	{
		bool done = false;

		while (!done)
		{
			done = true;

			for (int x = 1; x < mapSize - 1; x++)
			{
				for (int y = 1; y < mapSize - 1; y++)
				{
					int[] pos = { x, y };

					if (CanCarve(pos)) continue;

					// If it only has one exit it is a dead end
					int exits = 0;
					foreach (int[] dir in cardinalDirections)
					{
						if (!IsWall(pos, dir)) exits++;
					}

					if (exits > 1) continue;

					done = false;
					Carve(x, y, TileType.Wall, false);
				}
			}
		}
	}


	void StartRegion()
	{
		currentRegion++;
	}
	void Carve(int x, int y, TileType type = TileType.Floor, bool newRegion = true)
	{
		int[] pos = { x, y };

		levelTiles[x, y] = type;
		if (newRegion)
		{
			levelRegions[x, y] = currentRegion;
		}

		if (type == TileType.Door)
		{
			int[] regions = new int[2];
			foreach (int[] dir in cardinalDirections)
			{
				int region = levelRegions[x, y];
				if (region != -1)
				{
					// Try to add location, if it already exists just add to list
					try
					{
						List<int[]> posList = new List<int[]> { pos };
						doorConnectors.Add(region, posList);
					}
					catch (ArgumentException)
					{
						doorConnectors[region].Add(pos);
					}
				}
			}

		}
	}
	bool CanCarve(int[] pos, int[] dir)
	{
		// Returns false if the cell is already taken or out of map bounds
		if (!CanCarve(pos)) { return false; }
		int x = pos[0] + dir[0];
		int y = pos[1] + dir[1];
		if (!InBounds(x, y)) { return false; }


		// If travelling north or south check east and west cells
		if (dir[1] != 0)
		{
			int[] eastCell = { pos[0] + east[0], pos[1] + east[1] };
			int[] westCell = { pos[0] + west[0], pos[1] + west[1] };
			if (!CanCarve(eastCell) || !CanCarve(westCell)) { return false; }
		}
		// If travelling east or west check north and south cells
		else if (dir[0] != 0)
		{
			int[] northCell = { pos[0] + north[0], pos[1] + north[1] };
			int[] southCell = { pos[0] + south[0], pos[1] + south[1] };
			if (!CanCarve(northCell) || !CanCarve(southCell)) { return false; }
		}


		int[][] checkCells = null;
		if (dir == north) { checkCells = northCells; }
		else if (dir == south) { checkCells = southCells; }
		else if (dir == east) { checkCells = eastCells; }
		else if (dir == west) { checkCells = westCells; }
		else
		{
			//Invalid direction inputted
			return false;
		}
		foreach (int[] checkCell in checkCells)
		{
			int[] cell = { pos[0] + checkCell[0], pos[1] + checkCell[1] };
			if (!CanCarve(cell))
			{
				return false;
			}
		}

		// All of the surrounding walls in the direction are available so return true
		return true;
	}
	bool CanCarve(int[] pos)
	{
		// Returns false if the cell is already taken or out of map bounds
		int x = pos[0];
		int y = pos[1];
		// Checking if map is out of bounds
		if (!InBounds(x, y))
		{
			return false;
		}
		// return True if the cell is a wall (1)
		// false if the cell is a floor (0)
		return (levelTiles[x, y] == TileType.Wall);
	}
	bool IsWall(int[] pos, int[] dir)
	{
		int x = pos[0] + dir[0];
		int y = pos[1] + dir[1];

		return (levelTiles[x, y] == TileType.Wall);
	}
	bool IsWall(int x, int y, int[] dir)
	{
		int[] pos = { x, y };
		return IsWall(pos, dir);
	}
	bool InBounds(int x, int y)
	{
		// Checking if map is out of bounds
		if (!(0 <= x) || !(x < mapSize) ||
			!(0 <= y) || !(y < mapSize))
		{
			return false;
		}
		else return true;
	}
	void CreateRoom(Room room)
	{
		for (int x = room.x1; x < room.x2; x++)
		{
			for (int y = room.y1; y < room.y2; y++)
			{
				Carve(x, y, TileType.Room);
			}
		}

		roomList.Add(room);
	}
	float Distance(int[] pos1, int[] pos2)
	{
		return (float)Math.Sqrt(Math.Pow(pos1[0] - pos2[0], 2) + Math.Pow(pos1[1] - pos2[1], 2));
	}

	public void ClearLevel()
	{
		levelTiles = null;
	}
}

public class Room
{
	public int x1, y1, x2, y2;

	public Room(int x, int y, int width, int height)
	{
		this.x1 = x;
		this.y1 = y;
		this.x2 = x + width;
		this.y2 = y + height;
	}

	public bool Intersect(Room otherRoom)
	{
		return ((x1 <= otherRoom.x2 && x2 >= otherRoom.x1) &&
			(y1 <= otherRoom.y2 && y2 >= otherRoom.y1));
		//return ((x1 > otherRoom.x2 && x2 > otherRoom.x1) &&
		//(y1 > otherRoom.y2 && y2 > otherRoom.y1));
	}
}