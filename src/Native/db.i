%module Leveldb

%include std_string.i
%{
#include "write_batch.h"
#include "db.h"
#include "env.h"
#include "comparator.h"
#include "table_builder.h"
#include "table.h"
#include "options.h"
%}


%{
 namespace leveldb {
   class UserComparator : private Comparator {
     private : 
        std::string comparatorName; 
        int (*comparatorFunc)(const std::string& a, const std::string& b);
     public :   
        UserComparator(std::string name, int (*c)(const std::string& a, const std::string& b)) : comparatorName(name){
            this-> comparatorFunc = c;
        }
         
        // If *start < limit, changes *start to a short string in [start,limit).
   	    void FindShortestSeparator(std::string* start, const Slice& limit) {
   	      // Does nothing that's correct to allow optimization 
   	    }
   	  
   	    // Changes *key to a short string >= *key.
   	    void FindShortSuccessor(std::string* key) {
   	      // Does nothing that's correct to allow optimization
   	    }
   	    int Compare(const leveldb::Slice& a, const leveldb::Slice& b) const {
           return 0; 
        }
     
        
        const char* Name() const {
           return comparatorName.c_str();
        }
   };
  }
%}


namespace leveldb {
  
  %nodefaultctor;
  %nodefaultdtor Snapshot;
  class Snapshot {
  };
  %clearnodefaultctor;  

  struct WriteOptions {
    WriteOptions();
   
    // Default: false
    bool sync;

	   
    // If "post_write_snapshot" is non-NULL, and the write succeeds,
    // *post_write_snapshot will be modified to point to a snapshot of
    // the DB state immediately after this write.  The caller must call
    // DB::ReleaseSnapshot(*post_write_snapshotsnapshot) when the
    // snapshot is no longer needed.
    // Default: NULL
    //%rename(postWriteSnapshot) post_write_snapshot;
    //const Snapshot** post_write_snapshot;
    
   };
   
   
  class Status {
    public :
    // Returns true iff the status indicates success.
    bool ok();

    // Returns true iff the status indicates a NotFound error.
    %rename(isNotFound) IsNotFound;
    bool IsNotFound();

    std::string ToString();
  };

  enum CompressionType {
    // NOTE: do not change the values of existing entries, as these are
    // part of the persistent format on disk.
    kNoCompression     = 0x0,
    kSnappyCompression = 0x1
  };


  struct Options {
    Options();

    %rename(createIfMissing) create_if_missing;
    bool create_if_missing;

    // Default: false
    %rename(errorIfExists) error_if_exists;
    bool error_if_exists;

    // Default: false
    %rename(paranoidChecks) paranoid_checks;
    bool paranoid_checks;
  
    // Default: 4MB
    %rename(writeBufferSize) write_buffer_size;
    size_t write_buffer_size;

    // Default: 1000
    %rename(maxOpenFiles) max_open_files;
    int max_open_files;

    // Cache* block_cache;

    // Default: 4K
    %rename(blockSize) block_size;
    size_t block_size;
    
    // Default: 16
    %rename(blockRestartInterval) block_restart_interval;
    int block_restart_interval;
  
    CompressionType compression;
    
    // const Comparator* comparator;
  
  };
  
  
  struct ReadOptions {
  	
  	%rename(verifyChecksums) verify_checksums;
	bool verify_checksums;
	
	%rename(fillCache) fill_cache;
    bool fill_cache;

    // Default: NULL
    const Snapshot* snapshot;
  };
  
  // Destroy the contents of the specified database.
  // Be very careful using this method.
  Status DestroyDB(const std::string& name, const Options& options);

  Status RepairDB(const std::string& dbname, const Options& options);

}

%inline %{
 namespace leveldb {
    
   
   class DBWriteBatch {
      friend class DBAccessor;
      private : 
       WriteBatch wb;
      public :
       // Store the mapping "key->value" in the database.
       void Put(const char* key, const char* value) {
          wb.Put(Slice(key), Slice(value));
       }
       void Delete(const char* key) {
          wb.Delete(Slice(key));
       }
       void Clear() {
          wb.Clear();
       }
   };
   
   class DBIterator {
       friend class DBAccessor;
       friend class DBTable;
       leveldb::Iterator* it;
       DBIterator(leveldb::Iterator* i) {
         it = i;
       }
       public :
       ~DBIterator() { delete it; } 
         // An iterator is either positioned at a key/value pair, or not valid.  
         bool valid() { return it->Valid(); }
         
         void seekToFirst() { return it->SeekToFirst(); }
         
         void seekToLast() { return it->SeekToLast(); }
         
         void seek(const std::string& str) { return it->Seek(Slice(str)); }
  
         // REQUIRES: Valid()       
         void next() { return it-> Next(); }
         
         // REQUIRES: Valid()
         // After this call, Valid() istrue iff the iterator was not positioned at the first entry in source.
         void prev() { return it-> Prev(); }
         
         // REQUIRES: Valid()
         std::string key() { return it->key().ToString(); }
         
         // REQUIRES: !AtEnd() && !AtStart()
         std::string value() {
         		return it->value().ToString();
          }
         
         // If an error has occurred, return it.  Else return an ok status.
         Status status() { return it->status(); }
   };
   
   
	class DBTable {
	   private :
	     leveldb::Table* table;
	     DBTable(){};
 	   public :
 	     static DBTable* open(const Options& options, std::string filename,
 	     			long long fileSize) {
 	        leveldb::Table* t;
 	        RandomAccessFile* raf;
 	        Env* env = Env::Default();
 	        Status fileSt = env -> NewRandomAccessFile(filename, &raf);
 	        if(!fileSt.ok()){
 	           return NULL;
 	        }
 	        
 	     	Status st = leveldb::Table::Open(options, raf, fileSize, &t);
 	     	if(!st.ok()) {
 	     	   delete raf;
 	     	   return NULL;
 	     	}
 	     	DBTable* dt = new DBTable;
 	     	dt -> table = t;
 	     	return dt;
 	     }
 	     
 	     ~DBTable() {
 	     	delete table;
 	     }
 	      
  		 DBIterator* newIterator(const ReadOptions& opts) {
  		   leveldb::Iterator* iterator =  table -> NewIterator(opts);
  		   return new DBIterator(iterator); 
  		 }

         //long long approximateOffsetOf(const std::string& key) { table -> ApproximateOffsetOf(Slice(key)); }
   };
   
   
   class DBTableBuilder {
       TableBuilder* tableBuilder;
       WritableFile* wf;
       Options opts;
     public :
       DBTableBuilder(const Options& options) {
           opts = options;
       }
       
       ~DBTableBuilder() {
          if(tableBuilder) {
             finish();
          }
       }
       
       Status setOptions(const Options& options) {
           opts = options;
           if(!tableBuilder) {
           	  return Status::OK();
           } else {
              return tableBuilder -> ChangeOptions(options);
           }
       }
       
       Status getStatus() {
           if(!tableBuilder) {
           	  return Status::OK();
           }
           return tableBuilder -> status();
       }
       
       // open file to append to it
       Status open(const std::string& fname) {
           Env* env = Env::Default();
           Status st = env -> NewWritableFile(fname, &wf);
           if(st.ok()){
               tableBuilder = new TableBuilder(opts, wf);
           }
           return st;
       } 
       
       Status add(std::string key, std::string value) {
       		tableBuilder -> Add(Slice(key), Slice(value));
       		return tableBuilder -> status();
       } 
       
  	   
  	   void flush() { tableBuilder -> Flush(); }
  	   
  	   long long numEntries() { int64_t ui = tableBuilder -> NumEntries(); return ui;}
  	   
  	   long long fileSize() { int64_t ui = tableBuilder -> FileSize();  return ui;} 

  
  	   Status finish() {
  	       if(!tableBuilder) {
  	       	   return Status::OK();
  	       }
  	       Status res =  tableBuilder -> Finish();
  	       delete tableBuilder;
  	       delete wf;
  	       return res;
  	   }
  	   
  	   void abandon() {
  	        if(tableBuilder) {
  	       	   tableBuilder -> Abandon();
  	       }
  	   }
   };

   class DBAccessor {
     private :
       leveldb::DB* pointer;
     
     public :
     Status lastStatus;
     Status open(const Options& options,
                     const std::string& name) {
	    return DB::Open(options, name, &pointer);
     }
     
     std::string get(const ReadOptions& options, char const* key) {
          std::string val;
          lastStatus = pointer -> Get(options, Slice(key), &val);
          return val;
      }
       
      Status write(const WriteOptions& options, DBWriteBatch& updates) {
          lastStatus = pointer -> Write(options, &updates.wb);
          return lastStatus;
      } 
      
      Status put(const WriteOptions& options, const std::string key, const std::string value) {
          lastStatus = pointer -> Put(options, Slice(key), Slice(value));
          return lastStatus;
      }
            
      Status remove(const WriteOptions& options, const std::string key) {
           lastStatus = pointer -> Delete(options, Slice(key));
           return lastStatus;
      }
       
      // Return a heap-allocated iterator over the contents of the database.
  	  // Caller should delete the iterator when it is no longer needed.
      DBIterator* newIterator(const ReadOptions& options) {
         return new DBIterator(pointer -> NewIterator(options));
      };
      
      // Return a handle to the current DB state.  Iterators created with
      // this handle will all observe a stable snapshot of the current DB
      // state.  The caller must call ReleaseSnapshot(result) when the snapshot is no longer needed.
      const Snapshot* getSnapshot() {
         return pointer -> GetSnapshot();
      };
      
      // Release a previously acquired snapshot.  The caller must not
  	  // use "snapshot" after this call.
      void releaseSnapshot(const Snapshot* snapshot) {
         pointer -> ReleaseSnapshot(snapshot);
      };
      
      std::string getProperty(std::string property) {
      	 std::string value;
         if(pointer ->GetProperty(Slice(property),&value)) {
            return value;
         } else {
            // Can't return null in that case because of std::string
            // char* causes memory leak in generated cpp
            return "";
         }
      }      
  };
  
  Snapshot* getSnapshotValue(Snapshot** p) {
      if(p == NULL) {
          return NULL;
      }
      return *p;
  }

 }
 
%}
