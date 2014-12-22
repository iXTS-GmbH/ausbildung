using System;
using System.IO;

namespace ixts.Ausbildung.Kommentar_Zapper
{
    public class CommentX
    {
        private static State state = State.Source; 

        public static void CommentZapper(String line,StreamWriter writer)
        {
            foreach (var c in line)
            {
                switch (state)
                {
                        case State.Source:
                            switch (c)
                            {
                                case '/':
                                        state = State.Into;
                                    break;
                                case '*':
                                        writer.Write(c);
                                    break;
                                default:
                                        writer.Write(c);
                                    break;
                            }
                        break;
                        case State.Into:
                            switch (c)
                            {
                                case '/':
                                        writer.Write(c);
                                    break;
                                case '*':
                                        state = State.Comment;
                                    break;
                                default:
                                        state = State.Source;
                                        writer.Write('/' + c);
                                    break;
                            }
                        break;
                        case State.Comment:
                            switch (c)
                            {
                                case '/':
                                        //Nichts
                                    break;
                                case '*':
                                        state = State.Outof;
                                    break;
                                default:
                                        //Nichts
                                    break;
                            }
                        break;
                        case State.Outof:
                            switch (c)
                            {
                                case '/':
                                        state = State.Source;
                                        writer.Write(' ');
                                    break;
                                case '*':
                                        //Nichts
                                    break;
                                default:
                                        state = State.Comment;
                                    break;
                            }
                        break;
                }
            }
        }
    }

    public enum State{Source, Into, Comment, Outof}
}
