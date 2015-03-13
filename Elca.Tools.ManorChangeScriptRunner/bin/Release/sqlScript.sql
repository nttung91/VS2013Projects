CREATE OR REPLACE PACKAGE mpk_music_admin AS

  /*      Modul Comment
          -------------
          Modulname:          MIM_SPU.MPK_MUSIC_ADMIN
          Autor:              R. Oetzel
          Verwendung:
          Daten:              fis_job_requests
                              hau_job_requests
                              job_requests
                              print_queues
                              printers
                              prntr_frmt_trays
                              programs
          Modulverwendung:
          Installation:
          Stichwörter:        delete functions
  
          Beschreibung:       Verwaltung der Music-Tabellen (Package in der Application-Layer)
  
    Modification History
  
    Date      |  Description                                 | Author
   -----------|----------------------------------------------|----------------
   18.06.1998 | Erste Übergabe                               | R. Oetzel
   04.02.1999 | Renamed MPK_JOB_REQUEST to MPK_JOB_REQUESTS  | R. Oetzel
   14.04.1999 | Introduced Constant DAYS_TO_KEEP             | R. Oetzel
              | extended reorg delay: 3 days for jobs (ok)   | R. Oetzel
              |                       6 days for jobs (error)|
   21.11.2000 | Jobs mit Status Print_Error nicht loeschen   | R. Oetzel
   24.07.2002 | Changed job_status_printed                   | R. Oetzel
              |      to job_status_printed                   |
              | Don't delete Jobs from MUSIC_NT%             |
              | Jobs with other statuscodes remain           |
              | in JOB_REQUESTS 30 days                      |
   07.03.2002 | new procedures "check_queue" and             |M. Weckerle
              | "check_all_reportserver"                     |
   22.07.2003 | new procedure switch_jobs                    | R. Oetzel
   19.01.2004 | new procedure switch_printserver             | R. Oetzel
   08.02.2006 | delete jobs after 62 days                    | R. Oetzel
   19.05.2011 | delete jobs after 365 days                   | R. Oetzel
              | reorg_requests unabhängig vom Status         |
              |                                              |
   14.08.2014 | Grosse Umstellung !                          | R. Oetzel
              | Gelöscht wurden:                             |
              | - reorg_requests                             |
              | - check_all_reportserver                     |
              | - switch_jobs                                |
              | - switch_printserver                         |
              | Neu:                                         |
              | - may_delete_bch_queue                       |
              | - may_delete_listener                        |
              | - may_delete_printer                         |
              | - may_delete_prntr_frmt                      |
              | - may_delete_prntr_type                      |
              | - may_delete_program                         |
              | - may_delete_script                          |
              |                                              |
   09.03.2015 | Remove function may_delete_printer           | Tung Nguyen
  */

  FUNCTION may_delete_bch_queue(pv_batch_queue IN VARCHAR2
                               ,pv_reason      OUT VARCHAR2) RETURN NUMBER;
  FUNCTION may_delete_listener(pv_listener_name IN VARCHAR2
                              ,pv_reason        OUT VARCHAR2) RETURN NUMBER;
  FUNCTION may_delete_prntr_frmt(pv_frmt_id IN VARCHAR2
                                ,pv_reason  OUT VARCHAR2) RETURN NUMBER;
  FUNCTION may_delete_prntr_type(pv_pt_id  IN VARCHAR2
                                ,pv_reason OUT VARCHAR2) RETURN NUMBER;
  FUNCTION may_delete_program(pv_pgm_id IN VARCHAR2
                             ,pv_reason OUT VARCHAR2) RETURN NUMBER;
  FUNCTION may_delete_script(pv_script_id IN VARCHAR2
                            ,pv_reason    OUT VARCHAR2) RETURN NUMBER;

END mpk_music_admin;
/

CREATE OR REPLACE PACKAGE BODY mpk_music_admin AS

  FUNCTION may_delete_bch_queue(pv_batch_queue IN VARCHAR2
                               ,pv_reason      OUT VARCHAR2) RETURN NUMBER IS
    ln_dummy NUMBER;
  
  BEGIN
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   programs p
      WHERE  p.batch_queue = pv_batch_queue;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'BCH_QUEUE_PROGRAMS';
        RETURN(0);
    END;
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   job_requests jrq
      WHERE  jrq.batch_queue = pv_batch_queue;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'BCH_QUEUE_JOB_REQUESTS';
        RETURN(0);
    END;
    RETURN(1);
  END may_delete_bch_queue;

  FUNCTION may_delete_listener(pv_listener_name IN VARCHAR2
                              ,pv_reason        OUT VARCHAR2) RETURN NUMBER IS
    ln_dummy NUMBER;
  
  BEGIN
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   job_requests jrq
      WHERE  jrq.listener_name = pv_listener_name;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'LISTENERS_JOB_REQUESTS';
        RETURN(0);
    END;
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   programs p
      WHERE  p.listener_name = pv_listener_name;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'LISTENERS_PROGRAMS';
        RETURN(0);
    END;
    RETURN(1);
  END may_delete_listener;

  FUNCTION may_delete_prntr_frmt(pv_frmt_id IN VARCHAR2
                                ,pv_reason  OUT VARCHAR2) RETURN NUMBER IS
    ln_dummy NUMBER;
  
  BEGIN
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   programs p
      WHERE  p.frmt_frmt_id = pv_frmt_id;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'FRMT_PROGRAMS';
        RETURN(0);
    END;
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   prntr_frmt_trays pt
      WHERE  pt.frmt_frmt_id = pv_frmt_id;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'FRMT_PRNTR_FRMT_TRAYS';
        RETURN(0);
    END;
    RETURN(1);
  END may_delete_prntr_frmt;

  FUNCTION may_delete_prntr_type(pv_pt_id  IN VARCHAR2
                                ,pv_reason OUT VARCHAR2) RETURN NUMBER IS
    ln_dummy NUMBER;
  
  BEGIN
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   printers p
      WHERE  p.pt_pt_id = pv_pt_id;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'PRINTERS';
        RETURN(0);
    END;
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   prntr_frmt_trays pft
      WHERE  pft.pt_pt_id = pv_pt_id;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'PRNTR_FRMT_TRAYS';
        RETURN(0);
    END;
    RETURN(1);
  END may_delete_prntr_type;

  FUNCTION may_delete_program(pv_pgm_id IN VARCHAR2
                             ,pv_reason OUT VARCHAR2) RETURN NUMBER IS
    ln_dummy NUMBER;
  BEGIN
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   job_requests jrq
      WHERE  jrq.pgm_pgm_id = pv_pgm_id;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'JOB_REQUESTS';
        RETURN(0);
    END;
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   fis_job_requests fjrq
      WHERE  fjrq.pgm_pgm_id = pv_pgm_id;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'FIS_JOB_REQUESTS';
        RETURN(0);
    END;
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   hau_job_requests hjrq
      WHERE  hjrq.pgm_pgm_id = pv_pgm_id;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'HAU_JOB_REQUESTS';
        RETURN(0);
    END;
    RETURN(1);
  END may_delete_program;

  FUNCTION may_delete_script(pv_script_id IN VARCHAR2
                            ,pv_reason    OUT VARCHAR2) RETURN NUMBER IS
    ln_dummy NUMBER;
  
  BEGIN
    BEGIN
      SELECT 1
      INTO   ln_dummy
      FROM   programs p
      WHERE  p.script_id = pv_script_id;
      /* Single row found treated identically to TOO_MANY_ROWS */
      RAISE too_many_rows;
    EXCEPTION
      WHEN no_data_found THEN
        NULL;
      WHEN too_many_rows THEN
        pv_reason := 'SCRIPTS_PROGRAMS';
        RETURN(0);
    END;
    RETURN(1);
  END may_delete_script;

END mpk_music_admin;
/

