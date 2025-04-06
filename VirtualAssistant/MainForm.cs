using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsAppVirtualAssistant
{
    public partial class MainForm : Form
    {
        private ChatService _chat;
        private readonly GptClient _gpt;

        public MainForm(string apiKey)
        {
            InitializeComponent();
            _chat = new ChatService();
            _gpt = new GptClient(apiKey); // usamos el cliente de GPT con tu clave
            _chat.LimpiarConversacion();
            _chat.EnviarMensaje("Bot", "Yo", "¡Hola! Soy tu asistente virtual 🤖, ¿en qué puedo ayudarte hoy?", out _);
            LoadMessages();
        }

        private void LoadMessages()
        {
            pnlMessages.Controls.Clear();
            var mensajes = _chat.ObtenerMensajes();

            foreach (var msg in mensajes)
            {
                var bubble = new Label
                {
                    Text = $"{msg.Sender}: {msg.Text}",
                    AutoSize = true,
                    MaximumSize = new Size(300, 0),
                    Padding = new Padding(10),
                    Margin = new Padding(5),
                    BackColor = msg.Sender == "Yo" ? Color.LightGreen : Color.LightBlue
                };

                var container = new FlowLayoutPanel
                {
                    AutoSize = true,
                    FlowDirection = msg.Sender == "Yo" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                };

                container.Controls.Add(bubble);
                pnlMessages.Controls.Add(container);
            }

            if (pnlMessages.Controls.Count > 0)
            {
                pnlMessages.ScrollControlIntoView(pnlMessages.Controls[pnlMessages.Controls.Count - 1]);
                pnlMessages.AutoScrollPosition = new Point(0, pnlMessages.VerticalScroll.Maximum);
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string error;
            bool enviado = _chat.EnviarMensaje("Yo", "Bot", txtMessage.Text, out error);

            if (!enviado)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string entradaUsuario = txtMessage.Text;
            txtMessage.Clear();
            LoadMessages();

            await Task.Delay(1000); // Simular escribiendo...

            string respuestaBot = await _gpt.EnviarPreguntaAsync(entradaUsuario);
            _chat.EnviarMensaje("Bot", "Yo", respuestaBot, out _);
            LoadMessages();
        }

        private string ObtenerRespuestaBot(string entrada)
        {
            entrada = entrada.ToLower();
            if (entrada.Contains("hola")) return "¡Hola! ¿Cómo estás?";
            if (entrada.Contains("hora")) return $"Son las {DateTime.Now:HH:mm}";
            if (entrada.Contains("nombre")) return "Me llamo ChatBotcito 🤖";
            if (entrada.Contains("gracias")) return "¡De nada! Estoy para ayudarte.";
            return "Lo siento, aún estoy aprendiendo 🧠";
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSend.PerformClick();
            }
        }
    }
}