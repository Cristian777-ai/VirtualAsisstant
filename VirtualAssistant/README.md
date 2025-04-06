# 🤖 VirtualAssistant (C# + GPT)

Una aplicación de escritorio desarrollada en Windows Forms (C#), que actúa como un **asistente virtual inteligente** conectado a la **API de OpenAI (ChatGPT)**.

## 🚀 Funcionalidades

- Interfaz estilo chat con scroll automático
- Envío de mensajes con Enter
- Chat inteligente con integración a GPT-3.5
- Limpieza del historial en cada sesión nueva
- Respuestas automáticas simulando conversación humana
- Código organizado por capas (UI, lógica, base de datos, GPT)

## 🧠 ¿Cómo funciona?

1. El usuario escribe un mensaje en la interfaz
2. El sistema lo guarda localmente (SQLite)
3. Se hace una petición a OpenAI con el mensaje
4. El bot responde en la misma ventana de chat

## 🔧 Requisitos

- .NET 7 SDK o superior
- Visual Studio 2022+
- Conexión a internet
- Cuenta en [OpenAI](https://platform.openai.com)

## 🔐 API Key

Para usar GPT, necesitas una API Key de OpenAI:

1. Crea el archivo `apikey.txt` en la raíz del proyecto
2. Pega tu clave de OpenAI dentro (una sola línea):

```
sk-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
```

> ⚠️ **Nunca subas tu API Key a GitHub**

---

## 🛠️ Cómo ejecutar

```bash
git clone https://github.com/tu-usuario/VirtualAssistant.git
cd VirtualAssistant
dotnet build
dotnet run
```

También puedes abrir el `.csproj` con Visual Studio.

---

## 🧱 Tecnologías utilizadas

- C# (.NET 7)
- Windows Forms
- OpenAI API (ChatGPT)
- SQLite
- System.Net.Http.Json

---

## 👤 Autor

Desarrollado con ❤️ por **Cristian Stiven Ramírez Giraldo**

---

## 📄 Licencia

MIT License - Puedes usarlo, modificarlo y compartirlo libremente.