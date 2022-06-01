using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GroundClassLiberary.Airport;
//using GroundClassLiberary;
using System.Collections.Generic;
using Shapes2D.Drawing;
using Shapes2D;
using System.IO;
using Newtonsoft.Json;
using Flat.Graphics;
using System;
using GroundClassLiberary;

namespace GroundControlGame
{
    public class Game1 : Game
    {
        readonly GraphicsDeviceManager graphics;
        Screen screen;
        Sprites sprites;
        Shapes shapes;
        Camera Camera;
        SpriteBatch sprite;
        Airport Airport;
        Texture2D aircarft;
        BasicEffect basicEffect;
        SpriteFont SpriteFont;
        //private Shapes shapes;
        List<AirportPolygon> AirportPolygons;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            #region Set values

            RasterizerState rasterizerState = new RasterizerState
            {
                CullMode = CullMode.None
            };
            GraphicsDevice.RasterizerState = rasterizerState;
            SpriteFont = Content.Load<SpriteFont>("File");
            //Camera.SetZValue();
            sprite = new SpriteBatch(graphics.GraphicsDevice);
            graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;
            graphics.ApplyChanges();

            screen = new Screen(this, 1920, 1080);
            sprites = new Sprites(this);
            shapes = new Shapes(this);
            Camera = new Camera(screen);
            Viewport viewport = graphics.GraphicsDevice.Viewport;
            basicEffect = new BasicEffect(graphics.GraphicsDevice)
            {
                VertexColorEnabled = true,
                //View = Camera.Transform,
                View = Camera.View,
                //Projection = Matrix.CreateOrthographic(viewport.Width, viewport.Height, 0.001f, 1f),
                Projection = Camera.Projection,
                World = Matrix.Identity
            };
            #endregion
            #region Load airport
            string jsonstring;
            using (StreamReader streamReader = new StreamReader(@"H:\Codes\Games\GroundControl\GroundControlGame\Objects\Luxembourg.json"))
            {
                jsonstring = streamReader.ReadToEnd();
            }
            Airport = JsonConvert.DeserializeObject<Airport>(jsonstring);
            
            #endregion
            




            base.Initialize();
        }

        protected override void LoadContent()
        {
            Camera.MoveTo(Coordinate.ConvertToVector2(Airport.Coordinate));            
            AirportPolygons = new List<AirportPolygon>();
            
            for (int i = 0; i < Airport.Polygons.Count; i++)
            {
                string errorstring;
                var indices = new int[0];
                var vertices = Coordinate.ConvertToVectors2List(Airport.Polygons[i].BoundCoordinates).ToArray();
                var vertexArray = new VertexPositionColor[vertices.Length];
                //PolygonHelper.Triangulate(vertices, out indices, out errorstring);
                for (int c = 0; c < vertices.Length; c++)
                {
                    
                    vertexArray[c] = new VertexPositionColor(new Vector3(vertices[c], 0), CalculateColorFromString(Airport.Polygons[i].Color));
                }

                AirportPolygons.Add(new AirportPolygon() { Color = CalculateColorFromString(Airport.Polygons[i].Color), Name = Airport.Polygons[i].Name, Vertices = vertexArray });
                //Console.WriteLine(errorstring);
            }

            aircarft = Content.Load<Texture2D>("aircraft");

            //Camera.MoveTo(Airport.Polygons[0].BoundCoordinates[0].ToVector2());


            
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                Camera.Move(new Vector2(-5, 0));
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                Camera.Move(new Vector2(5, 0));
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
                Camera.Move(new Vector2(0, -5));
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                Camera.Move(new Vector2(0, 5));
            if (Keyboard.GetState().IsKeyDown(Keys.A)) Camera.DecZoom();
            if (Keyboard.GetState().IsKeyDown(Keys.E)) Camera.IncZoom();
            //Camera.UpdateCamera(graphics.GraphicsDevice.Viewport);

            basicEffect.View = Camera.View;


            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.SetRenderTarget(null);
            screen.Set();
            GraphicsDevice.Clear(Color.Black);
            string WriteMesg = "";
            //#region draw polygons
            List<VertexPositionColor> vertices = new List<VertexPositionColor>();
            List<short> triangleIndices = new List<short>();
            int triangleIndicesCount = 0;

            //vertices.Add(new VertexPositionColor(new Vector3(0, 6, 0), Color.Aqua));
            //vertices.Add(new VertexPositionColor(new Vector3(0.5215454f, 6.5458585f, 0), Color.Aqua));
            //vertices.Add(new VertexPositionColor(new Vector3(1, 6, 0), Color.Aqua));
            //triangleIndices.Add(0);
            //triangleIndices.Add(1);
            //triangleIndices.Add(2);

            //foreach (EffectPass effectPass in basicEffect.CurrentTechnique.Passes)
            //{
            //    effectPass.Apply();
            //    try { graphics.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices.ToArray(), 0, vertices.Count, triangleIndices.ToArray(), 0, triangleIndices.Count / 3); }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex);
            //    }
            //}
            shapes.Begin(Camera);
            Vector2[] verts = new Vector2[9];
            verts[0] = new Vector2(-40, 60);
            verts[1] = new Vector2(0, 20);
            verts[2] = new Vector2(20, 50);
            verts[3] = new Vector2(70, 0);
            verts[4] = new Vector2(50, -60);
            verts[5] = new Vector2(30, 30);
            verts[6] = new Vector2(0, -50);
            verts[7] = new Vector2(-60, 0);
            verts[8] = new Vector2(-20, 10);
            int[] tri;

            PolygonHelper.Triangulate(verts, out tri, out string errorms);

            //shapes.DrawPolygonFill(verts, tri, new Flat.FlatTransform(Camera.Position, 0f, 1f), Color.Red);
            //shapes.DrawPolygon(verts, new Flat.FlatTransform(Camera.Position, 0f, 1f), 1f, Color.Red);
            var newverts = new Vector2[0];
            for (int i = 0; i < AirportPolygons.Count; i++)
            {
                if (AirportPolygons[i].Name == "Test")
                {
                    newverts = new Vector2[AirportPolygons[i].Vertices.Length];
                    for (int c = 0; c < AirportPolygons[i].Vertices.Length; c++)
                    {
                        newverts[c] = new Vector2(AirportPolygons[i].Vertices[c].Position.X, AirportPolygons[i].Vertices[c].Position.Y);
                    }
                }
            }
            
            //for (int i = 0; i < AirportPolygons[0].Vertices.Length; i++)
            //{
            //    newverts[i] = new Vector2(AirportPolygons[0].Vertices[i].Position.X, AirportPolygons[0].Vertices[i].Position.Y);
            //}
            shapes.DrawPolygon(newverts, new Flat.FlatTransform(Camera.Position, 0f, 1f), 1f, Color.Red);
            shapes.End();

#if DEBUG
                sprite.Begin();
                sprite.DrawString(SpriteFont, $"cam coords: X: {Camera.Position.X} Y: {Camera.Position.Y} Zoomlevel: {Camera.Z}", new Vector2(0, 0), Color.White);
                sprite.DrawString(SpriteFont,WriteMesg, new Vector2(0, 2), Color.White);
                sprite.End();
#endif
            screen.UnSet();
            screen.Present(sprites);

                base.Draw(gameTime);
            
            
        }

        private static void CalculatePolygons(out VertexPositionColor[] vertices, out List<short> triangleIndices, GroundClassLiberary.Airport.Polygon polygon)
        {
            triangleIndices = new List<short>();
            vertices = new VertexPositionColor[polygon.BoundCoordinates.Count];
            for (int i = 0; i < polygon.BoundCoordinates.Count; i++)
            {
                vertices[i].Color = CalculateColorFromString(polygon.Color);
                vertices[i].Position = new Vector3(polygon.BoundCoordinates[i].ToVector2(), 0f);
            }
            
            
        }
        private static Color CalculateColorFromString(string color)
        {
            System.Drawing.Color tempColor = System.Drawing.Color.Gray;
            try { tempColor = System.Drawing.Color.FromName("SlateBlue"); }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Color.FromNonPremultiplied(tempColor.R, tempColor.G, tempColor.B, tempColor.A);
        }
    }
}
