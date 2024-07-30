import React, { useState, useEffect, useRef } from 'react';
import Editor from '@monaco-editor/react';
import axios from 'axios';
import { Typography } from '@mui/material';

function CodeEditor({ code, setErrors }) {
    const [editorValue, setEditorValue] = useState(code || '');
    const editorRef = useRef(null);

    useEffect(() => {
        setEditorValue(code); // Update editor when code prop changes
    }, [code]);

    const handleEditorChange = async (value) => {
        setEditorValue(value);

        try {
            const response = await axios.post('/api/analyze', { code: value });
            setErrors(response.data.errors); // Update errors from analysis
        } catch (error) {
            // Error handling (e.g., display error message to user)
            console.error('Error:', error);
        }
    };

    const handleEditorDidMount = (editor) => {
        editorRef.current = editor;
    };

    // Apply error decorations to the editor (if any)
    useEffect(() => {
        if (editorRef.current && setErrors) {
            const markers = errors.map(err => ({
                startLineNumber: err.line,
                endLineNumber: err.line,
                message: err.message,
                severity: /* Map severity from backend to Monaco severity */
            }));
            monaco.editor.setModelMarkers(editorRef.current.getModel(), null, markers);
        }
    }, [errors]);

    return (
        <div style={{ border: '1px solid lightgray', padding: '10px', marginTop: '10px' }}>
            <Typography variant="h6" component="div">
                Generated Smart Contract
            </Typography>
            <Editor
                height="500px" 
                defaultLanguage="csharp"
                defaultValue={editorValue}
                onChange={handleEditorChange}
                onMount={handleEditorDidMount}
                options={{
                    minimap: { enabled: true }, // Enable minimap
                    lineNumbers: "on", // Display line numbers
                }}
            />
        </div>
    );
}

export default CodeEditor;
