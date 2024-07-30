import React from 'react';
import ReactDOM from 'react-dom/client';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import App from './App';
import './index.css';

// Create a custom Material UI theme 
const theme = createTheme({
  // Customize your theme here (colors, typography, etc.)
  palette: {
    mode: 'light',  
    primary: {
      main: '#2196f3', // Blue
    },
    secondary: {
      main: '#f50057', // Pink
    },
  },
  typography: {
    fontFamily: 'Roboto, Arial, sans-serif',
  },
});

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <ThemeProvider theme={theme}> 
      <CssBaseline /> {/* Normalize CSS across browsers */}
      <App />
    </ThemeProvider>
  </React.StrictMode>
);

