<template>
    <div class="submissions-container">
        <h2>Form Submissions</h2>

        <div class="search-controls">
            <input type="text"
                   v-model="searchQuery"
                   placeholder="Search submissions..."
                   @input="searchSubmissions">
            <select v-model="selectedFormType" @change="searchSubmissions">
                <option value="">All Forms</option>
                <option value="contact">Contact Form</option>
                <!-- Add other form types as needed -->
            </select>
        </div>

        <div v-if="isLoading" class="loading">Loading...</div>

        <div v-else-if="submissions.length === 0" class="no-results">
            No submissions found.
        </div>

        <div v-else class="submissions-list">
            <div v-for="submission in submissions" :key="submission.id" class="submission-card">
                <h3>{{ submission.formType }} - {{ formatDate(submission.submissionDate) }}</h3>
                <div class="submission-details">
                    <div v-for="(value, key) in submission.formData" :key="key" class="detail-item">
                        <strong>{{ key }}:</strong>
                        <span>{{ formatValue(value) }}</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import axios from 'axios';

export default {
  setup() {
    const submissions = ref([]);
    const isLoading = ref(false);
    const searchQuery = ref('');
    const selectedFormType = ref('');

    const fetchSubmissions = async () => {
      isLoading.value = true;
      try {
          const response = await axios.get('http://localhost:5182/api/formsubmission');
        submissions.value = response.data;
      } catch (error) {
        console.error('Error fetching submissions:', error);
      } finally {
        isLoading.value = false;
      }
    };

    const searchSubmissions = async () => {
      isLoading.value = true;
      try {
          const response = await axios.get('http://localhost:5182/api/formsubmission/search', {
          params: {
            formType: selectedFormType.value,
            query: searchQuery.value
          }
        });
        submissions.value = response.data;
      } catch (error) {
        console.error('Error searching submissions:', error);
      } finally {
        isLoading.value = false;
      }
    };

    const formatDate = (dateString) => {
      const date = new Date(dateString);
      return date.toLocaleString();
    };

    const formatValue = (value) => {
      if (value === null || value === undefined) return '';
      if (typeof value === 'object') return JSON.stringify(value);
      return value.toString();
    };

    onMounted(() => {
      fetchSubmissions();
    });

    return {
      submissions,
      isLoading,
      searchQuery,
      selectedFormType,
      searchSubmissions,
      formatDate,
      formatValue
    };
  }
};
</script>

<style scoped>
    .submissions-container {
        max-width: 1000px;
        margin: 0 auto;
        padding: 20px;
    }

    .search-controls {
        display: flex;
        gap: 10px;
        margin-bottom: 20px;
    }

        .search-controls input {
            flex: 1;
            padding: 8px;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

        .search-controls select {
            padding: 8px;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

    .submissions-list {
        display: grid;
        grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
        gap: 20px;
    }

    .submission-card {
        background: white;
        border: 1px solid #ddd;
        border-radius: 8px;
        padding: 15px;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.05);
    }

        .submission-card h3 {
            margin-top: 0;
            color: #333;
            font-size: 1.1em;
        }

    .submission-details {
        margin-top: 10px;
    }

    .detail-item {
        margin-bottom: 8px;
        word-break: break-word;
    }

        .detail-item strong {
            color: #555;
        }

    .loading, .no-results {
        text-align: center;
        padding: 20px;
        color: #666;
    }
</style>