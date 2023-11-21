using System.Text;


/*
 * Strategy pattern is used when we have multiple algorithms for a specific task and client decides the actual implementation to be used at runtime.
 */
namespace Strategy
{
    public enum TextFormatType
    {
        PlainText,
        Markdown,
        Html
    }
    public interface ITextFormatter
    {
        void Begin(StringBuilder sb);
        void End(StringBuilder sb);
        void AddText(StringBuilder sb, string text);
    }

    public class PlainTextFormatter : ITextFormatter
    {
        public void Begin(StringBuilder sb)
        {
        }

        public void End(StringBuilder sb)
        {
        }

        public void AddText(StringBuilder sb, string text)
        {
            sb.Append(text);
        }
    }

    public class MarkdownFormatter : ITextFormatter
    {
        public void Begin(StringBuilder sb)
        {
            sb.AppendLine("Markdown Begin");
        }

        public void End(StringBuilder sb)
        {
            sb.AppendLine("Markdown End");
        }

        public void AddText(StringBuilder sb, string text)
        {
            sb.AppendLine($"* {text}");
        }
    }

    public class HtmlFormatter : ITextFormatter
    {
        public void Begin(StringBuilder sb)
        {
            sb.AppendLine("<ul>");
        }

        public void End(StringBuilder sb)
        {
            sb.AppendLine("</ul>");
        }

        public void AddText(StringBuilder sb, string text)
        {
            sb.AppendLine($"<li>{text}</li>");
        }
    }

    public class TextProcessor
    {
        private readonly StringBuilder _sb = new StringBuilder();
        private ITextFormatter _formatter;

        public void SetFormatter(ITextFormatter formatter)
        {
            _formatter = formatter;
        }

        public void SetFormat(TextFormatType format)
        {
            switch (format)
            {
                case TextFormatType.PlainText:
                    SetFormatter(new PlainTextFormatter());
                    break;
                case TextFormatType.Markdown:
                    SetFormatter(new MarkdownFormatter());
                    break;
                case TextFormatType.Html:
                    SetFormatter(new HtmlFormatter());
                    break;
            }
        }

        public void AppendList(IEnumerable<string> items)
        {
            _formatter.Begin(_sb);
            foreach (var item in items)
            {
                _formatter.AddText(_sb, item);
            }
            _formatter.End(_sb);
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}