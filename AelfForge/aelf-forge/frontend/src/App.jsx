import React, { useState } from 'react';
import { Container, Grid, Typography, CircularProgress } from '@mui/material';
import ScaffoldForm from './components/ScaffoldForm';
import CodeEditor from './components/CodeEditor';
import ErrorDisplay from './components/ErrorDisplay';
import DeploymentOptions from './components/DeploymentOptions';
import { showNotification } from './utils/helpers'; // Import notification function
import './App.css';

function App() {
    const [generatedCode, setGeneratedCode] = useState('');
    const [errors, setErrors] = useState([]);
    const [deploymentResult, setDeploymentResult] = useState(null);
    const [isLoading, setIsLoading] = useState(false); 

    const handleGenerate = async (code) => {
        setIsLoading(true);
        try {
            const response = await axios.post('/api/scaffold', {
                name: contractName,
                description,
                template,
            });
            setGeneratedCode(response.data.code);
            setErrors([]);
        } catch (error) {
            // Handle error with notification
            showNotification('Error generating contract. See console for details.', 'error');
            console.error('Error:', error);
        } finally {
            setIsLoading(false);
        }
    };

    const handleDeploy = async (network, parameters) => {
        setIsLoading(true);
        try {
            const response = await axios.post('/api/deploy', {
                code: generatedCode,
                network,
                parameters,
            });
            setDeploymentResult(response.data);
            showNotification('Contract deployed successfully!', 'success');
        } catch (error) {
            showNotification('Error deploying contract. See console for details.', 'error');
            console.error('Error:', error);
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <Container maxWidth="lg" sx={{ marginTop: '2rem' }}>
            <Typography variant="h4" gutterBottom>
                AelfForge - Smart Contract Generator
            </Typography>

            <Grid container spacing={3}>
                <Grid item xs={12} md={6}>
                    <ScaffoldForm onGenerate={handleGenerate} />
                </Grid>
                <Grid item xs={12} md={6}>
                    <CodeEditor code={generatedCode} setErrors={setErrors} />
                </Grid>
                <Grid item xs={12}>
                    {isLoading ? <CircularProgress /> : <ErrorDisplay errors={errors} />} 
                </Grid>
                {generatedCode && (
                    <Grid item xs={12}>
                        <DeploymentOptions onDeploy={handleDeploy} code={generatedCode} />
                    </Grid>
                )}
            </Grid>

            {/* Display deployment result (if available) */}
            {deploymentResult && (
                <Alert severity="info" sx={{ marginTop: 2 }}>
                    Deployment Result: {JSON.stringify(deploymentResult, null, 2)}
                </Alert>
            )}
        </Container>
    );
}

export default App;
