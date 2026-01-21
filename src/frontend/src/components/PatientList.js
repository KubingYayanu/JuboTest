import React from 'react';
import {
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  Paper,
  Typography,
  Box,
  Chip,
} from '@mui/material';
import PersonIcon from '@mui/icons-material/Person';

const PatientList = ({ patients, onPatientClick }) => {
  return (
    <Paper elevation={3} sx={{ p: 2 }}>
      <Typography variant="h5" gutterBottom sx={{ mb: 2 }}>
        病患列表
      </Typography>
      <List>
        {patients.map((patient) => (
          <ListItem
            key={patient.patientId}
            disablePadding
            sx={{ mb: 1 }}
          >
            <ListItemButton
              onClick={() => onPatientClick(patient)}
              sx={{
                border: '1px solid #e0e0e0',
                borderRadius: 1,
                '&:hover': {
                  backgroundColor: '#f5f5f5',
                },
              }}
            >
              <Box
                display="flex"
                alignItems="center"
                width="100%"
                justifyContent="space-between"
              >
                <Box display="flex" alignItems="center" gap={2}>
                  <PersonIcon color="primary" />
                  <ListItemText
                    primary={patient.name}
                    secondary={`病患 ID: ${patient.patientId}`}
                  />
                </Box>
                <Chip
                  label={`${patient.orders?.length || 0} 筆醫囑`}
                  color={patient.orders?.length > 0 ? 'primary' : 'default'}
                  size="small"
                />
              </Box>
            </ListItemButton>
          </ListItem>
        ))}
      </List>
    </Paper>
  );
};

export default PatientList;
