using System.Text;

namespace AdventOfCode2024._14_December;

public class Exercise2
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        long borderX = 101;
        // long borderX = 11;
        long borderY = 103;
        // long borderY = 7;
        long steps = 1367;
        // 1058
        // 1161
        // 1264
        // 1367
        // step size should be 103
        // 6620
        //p=0,4 v=3,-3
        var guards = _puzzleInput.Select(line =>
        {
            var split = line.Split(" ");
            var position = split.First().Split("=").Last().Split(",").Select(long.Parse).ToList();
            var velocity = split.Last().Split("=").Last().Split(",").Select(long.Parse).ToList();
            return new Guard((position[0], position[1]), (velocity[0], velocity[1]), (borderX, borderY));
        }).ToList();

        while(true)
        {
            // Read the user input
            string input = Console.ReadLine();
            
            // Check if the user wants to exit the loop
            if (input != null && input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exiting...");
                break;
            }
            steps+=103;
            var positions = guards
                .Select(x => x.PositionsAfterXSteps(steps))
                .ToList();
            // if(positions.Contains((0, 51)) is false) continue;
            
            var builder = new StringBuilder();
            for (var j = 0; j < borderY; j++)
            {
                for (var i = 0; i < borderX; i++)
                {
                    var count = positions.Count(x => i == x.Item1 && j == x.Item2);
                    if (count == 0)
                    {
                        builder.Append(" ");   
                    }
                    else
                    {
                        builder.Append("X");
                    }
                }
                builder.AppendLine();
            }
            Console.WriteLine(builder.ToString());   
            Console.WriteLine($"Result: {steps}");
            
        }
        
        // return 0;
        return 0;
        // To low: 214414200;
        //         233709840
    }

    private class Guard((long, long) initialPos, (long, long) velocity, (long, long) borders)
    {
        private (long, long) Position { get; set; } = initialPos;
        private (long, long) Velocity { get; set; } = velocity;

        public (long, long) PositionsAfterXSteps(long steps)
        {
            var x = (Position.Item1 + Velocity.Item1 * steps) % borders.Item1;
            if(x < 0) x += borders.Item1;
            var y = (Position.Item2 + Velocity.Item2 * steps) % borders.Item2;
            if(y < 0) y += borders.Item2;
            return (x, y);
        }
    }
}

/*
   
                                                                                X                       
                        X                                                   X                           
                                                                                                        
                                    X                                                                   
                          X  X                     X                                                    
                                                                                            X           
                                            X                                                           
                                                                                                        
                   X              X                                                           X         
                                                                                                        
                                X               X                                  X                    
                                               X                         X             X     X          
                                                            X                X                          
                                                                     X                                  
              X                                                                                         
                                        X                                                               
                 X                                                                                      
                                   X          X                               X                         
    X                                                                                                 X 
                              X   X           X                                                         
      X                                                                               X                 
                               X      X                                  X                              
     X                                                                                           X      
                                                       X                                                
                                          X X                                                           
                                                                                                        
   X                           X                                                     X                  
        X                                              X                                                
                                                                    XX                                  
                                                                                                        
                                                   X                                                    
                         X                                         X                                    
              X                                                    X                                    
         X                                                        X                                     
                   X                                                                                    
                                                                                   X                    
           X                  X                            X                                            
                                                                                                      X 
   X         X                                                                                          
      X                                                                                                 
                                                       X       X                        X               
           X                                                                                            
                                                                              X                    X    
                                   X                                                                    
                                                                      X                                 
                                               X                                                        
                                                                    X                                   
                                                                                                        
                                             X   X              X                  X                    
   X                                                                                                    
                                                                                               X        
                                       X                                                                
                                                                                                        
   X                                  X               XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX                   
                                                      X                             X                   
                                                      X                             X                   
                                                      X                             X                   
                                        X X           X                             X                   
                                                      X              X              X   X               
   X                                                  X             XXX             X                   
                       X                              X            XXXXX            X                   
                                                      X           XXXXXXX           X X    X            
                       X                     X        X          XXXXXXXXX          X          X        
                               X                      X            XXXXX            X                   
                                                      X           XXXXXXX           X        X          
                                                      X          XXXXXXXXX          X     X X           
                                                      X         XXXXXXXXXXX         X             X     
                 X                                    X        XXXXXXXXXXXXX        X                 X 
           X      X                                   X          XXXXXXXXX          X                   
             X                        X        X      X         XXXXXXXXXXX         X                   
                                                      X        XXXXXXXXXXXXX        X                  X
                     XX                         X     X       XXXXXXXXXXXXXXX       X      X            
               X      X   X                        X  X      XXXXXXXXXXXXXXXXX      X      X            
                                                      X        XXXXXXXXXXXXX        X                   
                                                      X       XXXXXXXXXXXXXXX       X                   
                                                      X      XXXXXXXXXXXXXXXXX      X X                 
                                                    X X     XXXXXXXXXXXXXXXXXXX     X                   
                                      XX     X        X    XXXXXXXXXXXXXXXXXXXXX    X                   
                                                      X             XXX             X                   
      X       X                                       X             XXX             X                   
                                                      X             XXX             X                   
                                                      X                             X                   
                                                      X                             X                   
                                                      X                             X                   
                                                    X X                             X                   
                                              X       XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX              X    
                                                                                        X               
                             X                                                                          
                                                                                                        
                      X                                                     X    X                      
                                X                                                                       
                      X                                                                                 
                                                                                                        
                                                                                                        
                                             X                                                          
                                                             X                                          
                           X                                                                            
                                                                   X                XX                  
                                                                  X                                     
                                                                                                        
                                                                                                       X
                                        X       X                                                    X  
                                                       X                 X                              
   
   Result: 6620
 */
