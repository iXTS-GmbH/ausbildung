using System;
using System.IO;

namespace ixts.Ausbildung.Kommentar_Zapper
{
    public enum StateDeluxe { Source, Into, Comment, Outof, LineComment }

    public class CommentXDeluxe
    {
        private static StateDeluxe state = StateDeluxe.Source;

        public static void CommentZapper(String line, StreamWriter writer)
        {
            foreach (var c in line)
            {
                switch (state)
                {
                        case StateDeluxe.Source:
                            switch (c)
                            {
                                case '/':
                                        state = StateDeluxe.Into;
                                    break;
                                case '*':
                                        writer.Write(c);
                                    break;
                                case '\n':
                                case '\r':
                                        writer.Write(c);
                                    break;
                                default:
                                        writer.Write(c);
                                    break;
                            }
                            break;
                        case StateDeluxe.Into:
                            switch (c)
                            {
                                case '/':
                                        state = StateDeluxe.LineComment;
                                    break;
                                case '*':
                                        state = StateDeluxe.Comment;
                                    break;
                                case '\n':
                                case '\r':
                                        state = StateDeluxe.Source;
                                        writer.Write('/' + c);
                                    break;
                                default:
                                        state = StateDeluxe.Source;
                                        writer.Write('/' + c);
                                    break;
                            }
                            break;
                        case StateDeluxe.Comment:
                            switch (c)
                            {
                                case '/':
                                    //Nichts
                                    break;
                                case '*':
                                        state = StateDeluxe.Outof;
                                    break;
                                case '\n':
                                case '\r':
                                        writer.Write(c);
                                    break;
                                default:
                                        //Nichts
                                    break;
                            }
                            break;
                        case StateDeluxe.Outof:
                            switch (c)
                            {
                                case '/':
                                        state = StateDeluxe.Source;
                                        writer.Write(' ');
                                    break;
                                case '*':
                                        //Nichts
                                    break;
                                case '\n':
                                case '\r':
                                        state = StateDeluxe.Comment;
                                        writer.Write(c);
                                    break;
                                default:
                                        state = StateDeluxe.Comment;
                                    break;
                            }
                            break;
                        case StateDeluxe.LineComment:
                            switch (c)
                            {
                                case '/':
                                        //Nichts
                                    break;
                                case '*':
                                        //Nichts
                                    break;
                                case '\n':
                                case '\r':
                                        state = StateDeluxe.Source;
                                        writer.Write(c);
                                    break;
                                default:
                                        //Nichts
                                    break;
                            }
                        break;
                }
            }
        }
    }
}
