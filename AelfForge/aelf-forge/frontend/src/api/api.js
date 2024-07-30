import axios from 'axios';

const baseURL = process.env.REACT_APP_API_URL || '/api'; // Use environment variable for flexibility

const api = axios.create({
    baseURL,
    headers: { 'Content-Type': 'application/json' } // Set default content type for JSON
});

// Smart Contract Scaffolding
export const generateContract = async (data) => {
    try {
        const response = await api.post('/scaffold', data);
        return response.data;
    } catch (error) {
        handleError(error, 'Error generating smart contract');
        throw error; // Re-throw the error so it can be handled in the component
    }
};

// Code Analysis
export const analyzeCode = async (code) => {
    try {
        const response = await api.post('/analyze', { code });
        return response.data.errors; // Assuming the backend returns an array of errors
    } catch (error) {
        handleError(error, 'Error analyzing code');
        throw error;
    }
};

// Deployment
export const deployContract = async (data) => {
    try {
        const response = await api.post('/deploy', data);
        return response.data;
    } catch (error) {
        handleError(error, 'Error deploying contract');
        throw error;
    }
};

// Generic Error Handler
function handleError(error, message) {
    if (error.response) {
        console.error(`${message}:`, error.response.data);
    } else if (error.request) {
        console.error(`${message}: No response received`);
    } else {
        console.error(`${message}:`, error.message);
    }
}

export default api;
